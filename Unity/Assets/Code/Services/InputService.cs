using Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Services
{
    public class InputService : ITickable
    {
        private readonly SceneLoader _sceneLoader;

        public InputService(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void Tick()
        {
            if (Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Home))
            {
                if (_sceneLoader.IsLoading || SceneManager.GetActiveScene().buildIndex == 0) return;

                LoadBackScene();
            }
        }

        private void LoadBackScene()
        {
            int index = SceneManager.GetActiveScene().buildIndex - 1;
            _sceneLoader.LoadScene(index);
        }
    }
}