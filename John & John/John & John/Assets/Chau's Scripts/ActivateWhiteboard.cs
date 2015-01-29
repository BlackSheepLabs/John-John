using UnityEngine;
using System.Collections;

public class ActivateWhiteboard : MonoBehaviour {

	
	public float whiteboardDist = 2.0f;
	public LayerMask pickupMask; //Number that represents the layers you can interact with
	private RaycastHit hitInfo;
	
	// Use this for initialization
	void Start () {
		
	}
	
	/* Update Method
	 * Send out a raycast forward to return what it hits
	 * If the hit object has the tag Button and is in the LayerMask
	 * If the user left clicks, the button will be activated
	 * Don't worry about double activation, button script will handle with states
	 */
	void Update () {
		if (Physics.Raycast(transform.position, transform.forward, out hitInfo, whiteboardDist, pickupMask)) {
			
			if (hitInfo.collider.gameObject.tag == "WhiteBoard") {
				//TODO Display some GUI thing that'll tell the user he can interact.

				if (Input.GetMouseButtonDown(0)) {
					
					hitInfo.collider.gameObject.SendMessage("ObjectActivate", SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}	
}