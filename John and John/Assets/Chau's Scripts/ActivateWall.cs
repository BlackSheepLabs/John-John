using UnityEngine;
using System.Collections;

public class ActivateWall : MonoBehaviour {
	enum ActivateState {ON, OFF}
	private ActivateState activateState;

	// Use this for initialization
	void Start () {
		renderer.enabled = false;
		activateState = ActivateState.OFF;
	}
	
	// Update is called once per frame
	void Update () {
		renderWall ();
	}

	void ObjectActivate() {
		activateState = ActivateState.ON;
	}
	
	void ObjectDeactivate() {
		activateState = ActivateState.OFF;
	}

	void renderWall() {
		if(activateState == ActivateState.ON)
		{
			renderer.enabled = true;
		}
	}
}
