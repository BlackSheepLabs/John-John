using UnityEngine;
using System.Collections;

public class ControlPauseBlur : MonoBehaviour {

	static public BlurEffect script;
	static public FPLooker script2;
	static public bool on; //Means the blur is on

	// Use this for initialization
	void Start () {
		script = gameObject.GetComponent<BlurEffect>();
		script2 = GetComponent<FPLooker>();
		on = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.P) && Application.loadedLevel!=0){
			if (!on){
				script.enabled = true;
				script2.enabled = false;
				on = true;
			}
			else if (on){
				on = false;
				script.enabled = false;
				script2.enabled = true;
			}
		}

	}
}
