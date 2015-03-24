using UnityEngine;
using System.Collections;

/* Script to attach to a button object
 * 
 * A button is an object the player can interact with a single time to activate something
 * 
 * Game Object Requirements:
 * 	Button should have a box collider the character can reach
 * 
 * Field Requirements:
 * 	User needs to enter the tag for the object that the switch will activate in the tag field
 * 	User must enter material for it to wear when it's on or off
 * 
 * Requirements for Activateable Objects:
 * 	Must contain an ObjectActivate() function to control what happens upon activation
 * 
 * Steps:
 *  Player presses button to activate objects
 *  Change state to reflect being pressed. Update based on state.
 *  Iterate through objects with tag entered by user.
 * 	Send message to activate.
 */
public class ButtonScript : MonoBehaviour {
	
	// State for button to tell whether it's already been pressed or not
	enum ButtonState {HAPPY, DEPRESSED};
	
	//Material used to signify that the switch is "on"
	//public Material onMaterial;
	//public Material offMaterial;
	
	//Tag that will have its objects activated
	//public string objectTag;
	public GameObject[] activatableObjects;
	
	private ButtonState buttonState;
	
	// Use this for initialization
	void Start () {
		buttonState = ButtonState.HAPPY;
	}
	
	// Update is called once per frame
	void Update () {
		if (buttonState == ButtonState.HAPPY) {
		//	gameObject.renderer.material = offMaterial;
		} else if (buttonState == ButtonState.DEPRESSED) {
		//	gameObject.renderer.material = onMaterial;
		}
	}
	
	/* ObjectActivate function
	 * Called when the user presses the button
	 * Checks if the button has already been pressed, if not, proceed.
	 * Set button to depressed
	 * 
	 */
	void ObjectActivate() {
		if (buttonState == ButtonState.HAPPY) {
			buttonState = ButtonState.DEPRESSED;

			if (activatableObjects.Length != 0) {
				foreach (GameObject obj in activatableObjects) {
					obj.SendMessage("ObjectActivate", SendMessageOptions.DontRequireReceiver);
				}
			}
			buttonState = ButtonState.HAPPY;
		}
	}
}
