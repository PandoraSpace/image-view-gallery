using UnityEngine;
using UnityEngine.UI;

namespace Providers
{
    public class ViewProvider : MonoBehaviour
    {
        [SerializeField] private Button _exitButton;
        [SerializeField] private Image _image;

        public Button ExitButton => _exitButton;

        public Image Image => _image;
    }
}