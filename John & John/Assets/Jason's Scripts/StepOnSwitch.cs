using UnityEngine;
using System.Collections;

/* Script to attach to a switch 
 *
 * A switch is an object the character can stand on to activate a thing, and step off to deactivate.
 * 
 * Game Object Requirement:
 * 	The switch should contain a box collider that extends slightly higher than it to allow for player
 * 	to step on it and activate collision
 * 
 * Field Requirements:
 * 	User needs to enter the tag for the object that the switch will activate in the tag field
 * 	User must enter material for it to wear when it's on or off.
 * 
 * Steps:
 * 	Player steps on switch to enter trigger.
 * 	Check for other.tag with player tag.
 *  Change state to reflect being stepped on. Update based on state.
 *  Iterate through objects with tag entered by user.
 * 	Send message to activate.
 * 
 * Requirements for Activatable Objects:
 * 	Must contain an ObjectActivate() function to control what happens upon activation
 * 	Must contain an ObjectDeactivate() function to control deactivation
 */
public class StepOnSwitch : MonoBehaviour {
	
	//Switch state will toggle switch on and off
	enum SwitchState {ON, OFF};
	
	//Material used to signify that the switch is "on"
	public Material onMaterial;
	public Material offMaterial;
	
	//Tag that will have its objects activated
	//public string objectTag;
	public GameObject[] activatedObjects;

	private SwitchState switchState;
	public bool swapped;
	private float swappedTimer;

	public float sinkDistance = 0.05f;
	float startHeight;

	void Start() {
		if(sinkDistance < 0.0f) sinkDistance *= -1;
		switchState = SwitchState.OFF;
		startHeight = transform.position.y;
		swapped = false;
		swappedTimer = .05f;
	}
	
	void Update() {
		if (switchState == SwitchState.ON) {
			gameObject.renderer.material = onMaterial;
		} else if (switchState == SwitchState.OFF) {
			gameObject.renderer.material = offMaterial;
		}

		if (swapped) {
			swappedTimer -= Time.deltaTime;
		}
		if (swappedTimer <= 0) {
			swapped = false;
			swappedTimer = .05f;
		}

		if (Input.GetMouseButtonDown(1)) {
			swapped = true;
		}

		if(switchState == SwitchState.ON && transform.position.y > startHeight-sinkDistance)
			transform.position -= Time.deltaTime*Vector3.up;
		else if(switchState == SwitchState.OFF && transform.position.y <= startHeight)
			transform.position += Time.deltaTime*Vector3.up;

		//Debug.Log(swapped);
	}
	
	
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			switchState = SwitchState.ON;
			foreach (GameObject obj in activatedObjects) {
				obj.SendMessage("ObjectActivate", SendMessageOptions.DontRequireReceiver);
			}
		}
		if (other.tag == "Clone") {
			switchState = SwitchState.ON;
			foreach (GameObject obj in activatedObjects) {
				obj.SendMessage("ObjectActivate", SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Player") {
			if (swapped == false) {
				switchState = SwitchState.OFF;
				foreach (GameObject obj in activatedObjects) {
					obj.SendMessage("ObjectDeactivate", SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}

}
