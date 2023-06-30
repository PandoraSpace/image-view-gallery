using System;
using System.Collections;
using Configs;
using Infrastructure;
using Providers;
using UnityEngine;
using UnityEngine.Networking;
using VContainer.Unity;

namespace Services
{
    public class ImageLoaderService : IStartable, IDisposable
    {
        private readonly GalleryProvider _gallery;
        private readonly LoadingImageConfig _config;
        private readonly CoroutineRunner _coroutine;
        private readonly ImageFactory _imageFactory;
        
        private int _currentImage = 1;
        private bool _isLoading;

        public ImageLoaderService(GalleryProvider gallery, LoadingImageConfig config, CoroutineRunner coroutine, 
            ImageFactory imageFactory)
        {
            _gallery = gallery;
            _config = config;
            _coroutine = coroutine;
            _imageFactory = imageFactory;
        }

        public void Start()
        {
            _gallery.ScrollRect.onValueChanged.AddListener(CheckLoadingImage);
            _coroutine.Run(LoadTextureFromServer(_config.Path));
        }


        public void Dispose()
        {
            _gallery.ScrollRect.onValueChanged.RemoveListener(CheckLoadingImage);
        }

        private void CheckLoadingImage(Vector2 position)
        {
            if (position.y > 0f || _isLoading) return;
            
            _coroutine.Run(LoadTextureFromServer(_config.Path));
        }

        private IEnumerator LoadTextureFromServer(string url)
        {
            _isLoading = true;

            for (var i = 0; i < _config.ImagesPerPage; i++)
            {
                UnityWebRequest request = UnityWebRequestTexture.GetTexture(url + $"{_currentImage}.jpg");
                _currentImage++;
                
                _gallery.LoadingIcon.transform.SetAsLastSibling();
                _gallery.LoadingIcon.SetActive(true);
                yield return request.SendWebRequest();
                _gallery.LoadingIcon.SetActive(false);

                ProcessRequest(request);
                request.Dispose();
            }

            _isLoading = false;
        }

        private void ProcessRequest(UnityWebRequest request)
        {
            if (request.isDone)
                GetTexture(request);
            else
            {
                _coroutine.Stop(LoadTextureFromServer(_config.Path));
                _gallery.ScrollRect.onValueChanged.RemoveListener(CheckLoadingImage);
            }
        }

        private void GetTexture(UnityWebRequest request)
        {
            Texture2D texture = DownloadHandlerTexture.GetContent(request);
            _imageFactory.Create(texture);
        }
    }
}