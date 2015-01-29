using UnityEngine;
using System.Collections;

public class PracticeWindows : MonoBehaviour {

	private Rect window = new Rect (20,200,200,200);
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		window = GUI.Window(0,window,WindowFunct,"Inventory");
	}

	void WindowFunct (int windowID) {
		//This can be replaced by anything you want inside of the window.
		GUI.Label (new Rect(20,20,100,50),"Options");
		//Makes the window dragable.
		GUI.DragWindow(new Rect(0,0,200,20));
	}
}
