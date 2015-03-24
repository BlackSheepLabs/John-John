using UnityEngine;
using System.Collections;

public class RisingStairs : MonoBehaviour {
	enum ActivateState {ON, OFF}
	private ActivateState activateState;

	GeneralTimer AnimTimer;
	// Use this for initialization
	void Start () {
		//animation.Stop();
		activateState = ActivateState.OFF;
		//animation.wrapMode = WrapMode.Once;
		//GetComponent<Animator>().SetBool("Rise",true);
	}
	
	// Update is called once per frame
	void Update () {
		//if(GetComponent<Animator>().GetBool("Rise"))
		//	Debug.Log("laksjdhfoie\n");

	}

	void ObjectActivate() {
		activateState = ActivateState.ON;
		GetComponent<Animator>().SetBool("Rise",true);
	}

	void ObjectDeactivate() {
		activateState = ActivateState.OFF;
		GetComponent<Animator>().SetBool("Rise",false);
	}
}

