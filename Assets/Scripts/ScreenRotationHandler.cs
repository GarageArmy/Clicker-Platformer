using UnityEngine;
using System.Collections;

public class ScreenRotationHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.autorotateToPortrait = false;
		Screen.autorotateToLandscapeLeft = true;
		Screen.autorotateToLandscapeRight = true;
		Screen.autorotateToPortraitUpsideDown = false;
		Screen.orientation = ScreenOrientation.AutoRotation;
	}

}
