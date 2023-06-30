using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Providers
{
    public class ImageProvider : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private RawImage _image;

        public RawImage Image => _image;
        public event Action<Texture> OnClick;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick?.Invoke(_image.texture);
        }
    }
}