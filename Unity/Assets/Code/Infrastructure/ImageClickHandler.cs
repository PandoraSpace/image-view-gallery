using Core;
using UnityEngine;

namespace Infrastructure
{
    public class ImageClickHandler
    {
        private readonly SceneLoader _sceneLoader;
        
        public Texture SelectedTexture { get; private set; }

        public ImageClickHandler(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void ClickAtImage(Texture texture)
        {
            SelectedTexture = texture;
            _sceneLoader.LoadScene(Scene.View);
        }
    }
}