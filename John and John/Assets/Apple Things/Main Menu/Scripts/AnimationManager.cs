using UnityEngine;
using System.Collections;

public class AnimationManager : MonoBehaviour {
	
	public static GameObject [] shadow;
	public static GameObject mainCam;
	public static GameObject blurCam;
	ExitGUI exitScript;
	// Use this for initialization
	void Start () {
		shadow = GameObject.FindGameObjectsWithTag("ShadowText");
		mainCam = GameObject.FindGameObjectWithTag("MainCamera");
		blurCam = GameObject.FindGameObjectWithTag("BlurCamera");
	}
	
	// Update is called once per frame
	void Update () {
	
		//Turn on the exit screen.
		if (Input.GetKeyDown(KeyCode.Escape)){
			exitScript = GetComponent<ExitGUI>();
			exitScript.enabled = true;
			ControlPauseBlur.script.enabled = true;
			Time.timeScale = 0.0f;
		}
	}
	
	public static bool animationIsPlaying(){
		return (shadow[0].animation.isPlaying || shadow[1].animation.isPlaying || 
				shadow[2].animation.isPlaying || mainCam.animation.isPlaying ||
		        blurCam.animation.isPlaying);
	}
}
