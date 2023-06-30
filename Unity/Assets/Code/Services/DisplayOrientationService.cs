using Core;
using UnityEngine;

namespace Services
{
    public class DisplayOrientationService
    {
        public void SetOrientaton(Orientation orientation)
        {
            switch (orientation)
            {
                case Orientation.Portrait:
                    Screen.orientation = ScreenOrientation.Portrait;
                    Screen.orientation = ScreenOrientation.AutoRotation;
                    Screen.autorotateToPortrait = Screen.autorotateToPortraitUpsideDown = true;
                    Screen.autorotateToLandscapeLeft = Screen.autorotateToLandscapeRight = false;
                    break;
                
                case Orientation.Any:
                    Screen.orientation = ScreenOrientation.AutoRotation;
                    Screen.autorotateToPortrait = Screen.autorotateToPortraitUpsideDown = true;
                    Screen.autorotateToLandscapeLeft = Screen.autorotateToLandscapeRight = true;
                    break;
            }
        }
    }
}