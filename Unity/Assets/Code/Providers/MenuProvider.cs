using UnityEngine;
using UnityEngine.UI;

namespace Providers
{
    public class MenuProvider : MonoBehaviour
    {
        [SerializeField] private Button _galleryButton;

        public Button GalleryButton => _galleryButton;
    }
}