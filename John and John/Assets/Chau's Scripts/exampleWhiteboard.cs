using UnityEngine;
using System.Collections;

public class exampleWhiteboard : MonoBehaviour {
	enum ActivateState {ON, OFF}
	private ActivateState activateState;


	// Use this for initialization
	void Start () {
		activateState = ActivateState.OFF;
	}
	
	// Update is called once per frame
	void Update () {
	

	}


	void ObjectActivate() {
		activateState = ActivateState.ON;
		Debug.Log ("Whiteboard is active");
	}
	
	void ObjectDeactivate() {
		activateState = ActivateState.OFF;
	}
	

	void OnGUI()
	{
		if(activateState == ActivateState.ON)
		{
			GUI.Box (new Rect (Screen.width / 2,Screen.height / 2,200,200), "WhiteBoard Text");
		}
	}
}
