using System;
using System.Collections.Generic;
using Configs;
using Providers;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Infrastructure
{
    public class ImageFactory : IDisposable
    {
        private readonly RectTransform _parent;
        private readonly ImageProvider _prefab;
        private readonly ImageClickHandler _imageClickHandler;
        private List<ImageProvider> _imagesList;

        public ImageFactory(GalleryProvider galleryProvider, LoadingImageConfig loadingImageConfig, ImageClickHandler imageClickHandler)
        {
            _parent = galleryProvider.Content;
            _prefab = loadingImageConfig.ImagePrefab;
            _imageClickHandler = imageClickHandler;

            _imagesList = new List<ImageProvider>();
        }
        
        public ImageProvider Create(Texture2D texture)
        {
            ImageProvider image = Object.Instantiate(_prefab, _parent);
            image.Image.texture = texture;
            image.OnClick += _imageClickHandler.ClickAtImage;
            _imagesList.Add(image);
            return image;
        }

        public void Dispose()
        {
            foreach (ImageProvider image in _imagesList)
                image.OnClick -= _imageClickHandler.ClickAtImage;
        }
    }
}