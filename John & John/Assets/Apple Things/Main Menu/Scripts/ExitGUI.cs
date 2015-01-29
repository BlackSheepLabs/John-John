using UnityEngine;
using System.Collections;

public class ExitGUI : MonoBehaviour {

	public GUISkin custStyle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI(){
		GUI.skin = custStyle;

		GUI.Box(new Rect(Screen.width/4,Screen.height/2.3f,Screen.width/2,Screen.height/8),"Exit?");
		if (GUI.Button(new Rect(Screen.width/4+5.0f,Screen.height/2.0f,Screen.width/8,Screen.height/20),"No")){
			ControlPauseBlur.script.enabled = false;
			this.enabled = false;
			Time.timeScale = 1.0f;
		}
		if (GUI.Button(new Rect(Screen.width/4+20.0f+Screen.width/8,Screen.height/2.0f,
		                        Screen.width/8,Screen.height/20),"Yes")){
			Application.Quit();
		}
	}
}
