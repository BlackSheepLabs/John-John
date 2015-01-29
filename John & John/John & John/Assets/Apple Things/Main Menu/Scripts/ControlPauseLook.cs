using UnityEngine;
using System.Collections;

public class ControlPauseLook : MonoBehaviour {

	static public FPLooker script;
	static public bool on;

	// Use this for initialization
	void Start () {
		on = false;
		script = GetComponent<FPLooker>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.P) && Application.loadedLevel!=0){
			if (!on){
				on = true;
				script.enabled = false;
			}
			else if (on){
				on = false;
				script.enabled = true;
			}
		}

	}
}
