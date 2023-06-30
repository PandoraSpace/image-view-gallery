using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Providers
{
    public class CurtainProvider : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _progressText;
        [SerializeField] private Image _progressBar;

        public TextMeshProUGUI ProgressText => _progressText;

        public Image ProgressBar => _progressBar;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}