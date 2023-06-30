using System;
using Core;
using Infrastructure;
using Providers;
using Services;
using UnityEngine;
using VContainer.Unity;

namespace CompositionRoot
{
    public class ViewEntryPoint : IStartable, IDisposable
    {
        private readonly ImageClickHandler _imageClickHandler;
        private readonly ViewProvider _viewProvider;
        private readonly DisplayOrientationService _displayOrientation;
        private readonly SceneLoader _sceneLoader;

        public ViewEntryPoint(ImageClickHandler imageClickHandler, ViewProvider viewProvider, 
            DisplayOrientationService displayOrientation, SceneLoader sceneLoader)
        {
            _imageClickHandler = imageClickHandler;
            _viewProvider = viewProvider;
            _displayOrientation = displayOrientation;
            _sceneLoader = sceneLoader;
        }

        public void Start()
        {
            _displayOrientation.SetOrientaton(Orientation.Any);
            SetSelectTexture();
            _viewProvider.ExitButton.onClick.AddListener(LoadGalleryScene);
        }

        public void Dispose()
        {
            _viewProvider.ExitButton.onClick.RemoveListener(LoadGalleryScene);
        }

        private void SetSelectTexture()
        {
            Texture texture = _imageClickHandler.SelectedTexture;
            _viewProvider.Image.sprite = Sprite.Create((Texture2D)texture, new Rect(0, 0, texture.width, texture.height),
                Vector2.one * 0.5f);
        }

        private void LoadGalleryScene()
        {
            _sceneLoader.LoadScene(Scene.Gallery);
        }
    }
}