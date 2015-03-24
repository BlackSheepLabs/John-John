using UnityEngine;
using System.Collections;

/* Script to attach to player so he can press the buttons
 * 
 * Game Object Requirements:
 * 	Should be attached to the player.
 * 
 * Button Object Requirements
 * 	Objects to be used as buttons should contain the tag "Button"
 * 	Button should have an ObjectActivate() function that will be called once the user presses button
 * 	Should have a field for the objectTag of the objects it wants to activate
 * 	Should iterate through those objects and activate each of them.
 * 
 * Field Requirements:
 * 	User must enter the layer the button is in in the LayerMask
 * 
 * Steps:
 * 	Send a raycast out in front of the player and record the hit object.
 * 	If the object hit is a button object, write some message to the player telling them they can interact.
 * 	Check for player click.  When it clicks, send message to the button to activate object.
 * 
 */
public class ButtonPress : MonoBehaviour {
	
	public float buttonPressDist = 2.0f;
	public LayerMask pickupMask; //Number that represents the layers you can interact with
	private RaycastHit hitInfo;

	//Rect backBox = new Rect(Screen.width/2 - 75 ,Screen.height/2 - 12, 150, 25);
	Rect backBox = new Rect(Screen.width/3 ,Screen.height/2 - 12, 215, 30);
	public string displayText;
	bool pointedAt;
	public GUISkin custSkin;

	//testcode//
	public GameObject targetCube;
	//testcode//
	
	// Use this for initialization
	void Start () {
		pointedAt = false;
		displayText = "(Click to Activate)";
	}
	
	/* Update Method
	 * Send out a raycast forward to return what it hits
	 * If the hit object has the tag Button and is in the LayerMask
	 * If the user left clicks, the button will be activated
	 * Don't worry about double activation, button script will handle with states
	 */
	void Update () {
		if (Physics.Raycast(transform.position, transform.forward, out hitInfo, buttonPressDist, pickupMask)) {

			if (hitInfo.collider.gameObject.tag == "Button") {
				//TODO Display some GUI thing that'll tell the user he can interact.
				pointedAt = true;
				Debug.DrawRay(transform.position,buttonPressDist*transform.forward,Color.green);
				if (Input.GetMouseButtonDown(0)) {
					hitInfo.collider.gameObject.SendMessage("ObjectActivate", SendMessageOptions.DontRequireReceiver);
				}
			}
			else {
				pointedAt = false;
				Debug.DrawRay(transform.position,buttonPressDist*transform.forward,Color.yellow);
			}
		}
		else {
			pointedAt = false;
			Debug.DrawRay(transform.position,buttonPressDist*transform.forward,Color.red);
		}
	}

	void OnGUI() {
		GUI.skin = custSkin;
		if(pointedAt)
		{
			GUI.backgroundColor = Color.white;
			GUI.Box(backBox, displayText);
		}

	}
			
}
