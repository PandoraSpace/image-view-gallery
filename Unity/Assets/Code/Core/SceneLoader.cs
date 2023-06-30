using Providers;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Core
{
    public class SceneLoader : ITickable
    {
        private const float LOAD_TIME = 2.5f;
        private readonly CurtainProvider _curtain;
        private float _currentTimeLoading;
        
        public bool IsLoading { get; private set; }

        public SceneLoader(CurtainProvider curtain)
        {
            _curtain = curtain;
        }

        public void LoadScene(Scene scene)
        {
            SetActiveCurtain(true);
            SceneManager.LoadScene((byte)scene);
        }

        public void LoadScene(int index)
        {
            SetActiveCurtain(true);
            SceneManager.LoadScene(index);
        }

        public void Tick()
        {
            if (IsLoading == false) return;

            ShowNewValue();
            CheckEndTime();
        }

        private void CheckEndTime()
        {
            if (!(_currentTimeLoading >= LOAD_TIME)) return;

            SetActiveCurtain(false);
        }

        private void SetActiveCurtain(bool isActive)
        {
            _currentTimeLoading = 0f;
            _curtain.ProgressBar.fillAmount = 0f;
            IsLoading = isActive;
            _curtain.gameObject.SetActive(isActive);
        }

        private void ShowNewValue()
        {
            _currentTimeLoading += Time.deltaTime;
            float percent = _currentTimeLoading / LOAD_TIME;
            _curtain.ProgressText.SetText("{0}%", Mathf.Round(percent * 100f));
            _curtain.ProgressBar.fillAmount = percent;
        }
    }
}