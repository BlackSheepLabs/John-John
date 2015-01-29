using UnityEngine;
using System.Collections;

public class MoveStuff : MonoBehaviour {
	private GameObject obj;
	bool canPickUp = false;
	bool pickedUp = false;
	Rigidbody pickUpRigidBody;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E)) {
						if (obj.tag == "pickup") {
								if (pickedUp) {
										Debug.Log ("Setting down");
										obj.transform.collider.enabled = true;
										obj.transform.parent = null;
										obj.transform.rigidbody.WakeUp();
										obj.transform.rigidbody.freezeRotation = false;
										pickedUp = false;
										canPickUp = false;
								}
								if (canPickUp) {
										Debug.Log ("Picking up");
										obj.transform.parent = gameObject.transform;
										obj.transform.rigidbody.freezeRotation = true;
										obj.transform.rigidbody.Sleep();
									//	Destroy(pickUpRigidBody);
					obj.transform.collider.enabled = false;
										pickedUp = true;
								}
						}
				}
	}

	void OnGUI() {

		if(canPickUp && !pickedUp)
			GUI.Label (new Rect (Screen.width / 2, Screen.height / 2, 200, 50), "Press 'E' to Pick Up");
	}
	
	void OnTriggerStay(Collider other) {

		Debug.Log ("Enter Trigger");

		obj = other.transform.parent.gameObject;
		if(obj.tag == "pickup")
			canPickUp = true;
	}

	void OnTriggerExit() {
		canPickUp = false;
	}
}
