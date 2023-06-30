using Core;
using Services;
using VContainer.Unity;

namespace CompositionRoot
{
    public class GalleryEntryPoint : IStartable
    {
        private readonly DisplayOrientationService _displayOrientation;

        public GalleryEntryPoint(DisplayOrientationService displayOrientation)
        {
            _displayOrientation = displayOrientation;
        }

        public void Start()
        {
            _displayOrientation.SetOrientaton(Orientation.Portrait);
        }
    }
}