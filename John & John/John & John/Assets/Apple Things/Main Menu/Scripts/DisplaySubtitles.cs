using UnityEngine;
using System.Collections;

public class DisplaySubtitles : SubtitleMaster {
	//This script will display subtitles
	//Place it on whichever object is playing sounds
	//How do you initialize an array of audio files?

	string[] subtitles;
	bool worked;
	bool display = false;

	// Use this for initialization
	void Start () {
		//These are place holders. None of the values are correct.
		worked = loadText("file",100,subtitles); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		if (display){
			//Display a box behind the text
			//Display the text
		}
	}
}
