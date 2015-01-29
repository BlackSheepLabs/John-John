using UnityEngine;
using System.Collections;

public class PracticeVolumeCtrl : MonoBehaviour {

	private bool muteToggle = false;
	private float curVol = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		curVol = GUI.HorizontalSlider(new Rect(300,150,180,50),curVol,0.0f,1.0f);
		AudioListener.volume = curVol;

		//The following will mute some sound using a toggle button.
		muteToggle = GUI.Toggle(new Rect(300,100,100,50),muteToggle,"Mute");
		if (!muteToggle){
			AudioListener.volume = curVol;
		}
		else AudioListener.volume = 0;


	}
}
