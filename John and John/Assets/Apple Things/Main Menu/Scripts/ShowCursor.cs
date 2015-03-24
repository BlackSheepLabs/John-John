using UnityEngine;
using System.Collections;

public class ShowCursor : MonoBehaviour {

	public Texture2D cursor;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		Screen.showCursor = false;
	}

	void OnGUI () {
		//Only show when paused
		if (PauseControl.isPaused || Application.loadedLevelName == "MainMenu" || Application.loadedLevelName == "EndMenu"){
			Vector3 mousePos = Input.mousePosition;
			Rect temp = new Rect(mousePos.x,Screen.height - mousePos.y,cursor.width,cursor.height);
			GUI.Label(temp,cursor);
		}
	}
}
