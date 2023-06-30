using System;
using Core;
using Providers;
using Services;
using VContainer.Unity;

namespace CompositionRoot
{
    public class MenuEntryPoint : IStartable, IDisposable
    {
        private readonly SceneLoader _sceneLoader;
        private readonly MenuProvider _menuProvider;
        private readonly DisplayOrientationService _displayOrientation;
        
        private MenuEntryPoint(SceneLoader sceneLoader, MenuProvider menuProvider, DisplayOrientationService displayOrientation)
        {
            _sceneLoader = sceneLoader;
            _menuProvider = menuProvider;
            _displayOrientation = displayOrientation;
        }
        
        public void Start()
        {
            _displayOrientation.SetOrientaton(Orientation.Portrait);
            _menuProvider.GalleryButton.onClick.AddListener(LoadGalleryScene);
        }

        public void Dispose()
        {
            _menuProvider.GalleryButton.onClick.RemoveListener(LoadGalleryScene);
        }

        private void LoadGalleryScene()
        {
            _sceneLoader.LoadScene(Scene.Gallery);
        }
    }
}