using UnityEngine;
using System.Collections;

public class PauseMenuGUI : MonoBehaviour {

	public GUISkin custSkin;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		GUI.Box(new Rect(Screen.width/4,Screen.height/16,
		                 Screen.width-(Screen.width/2 * 2),Screen.height-(Screen.height/16 * 2)),"");

		if (GUI.Button(new Rect(Screen.width/7,Screen.height/1.15f,Screen.width/6,Screen.height/25),"Back")){

		}
	}
}
