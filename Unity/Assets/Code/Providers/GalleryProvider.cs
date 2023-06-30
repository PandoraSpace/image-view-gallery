using UnityEngine;
using UnityEngine.UI;

namespace Providers
{
    public class GalleryProvider : MonoBehaviour
    {
        [SerializeField] private ScrollRect _scrollRect;
        [SerializeField] private RectTransform _content;
        [SerializeField] private GameObject _loadingIcon;

        public ScrollRect ScrollRect => _scrollRect;

        public RectTransform Content => _content;

        public GameObject LoadingIcon => _loadingIcon;
    }
}