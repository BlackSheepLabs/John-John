using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Script to be put on a collection of SHOOTDABULLETs
//Will turn off shooting upon activation
//NOTE: IT NOW DOES NOT JUST TURN OFF ON ACTIVATION
//
public class DeactivateBulletsOnTrigger : Trigger {

	public List<Transform> shooters;

	public bool IsActive
	{get {return this.currentState == State.Activated;} }

	void Awake () {
		responseObject = null;
		duration = 1.0f;

		//Populate the list with the actual shooters
		foreach (Transform shooter in gameObject.GetComponentsInChildren<Transform>())
			if (shooter.GetComponent<weaponScript>() != null)
				shooters.Add(shooter);
	}

	//Once the player presses the button, turn off bullets
	public override void OnActivate() {
		Debug.Log("Activating the deactivating");
		//Get each collection of shooters and switch their enabled-ness
		foreach (Transform shooter in shooters) {
			if (shooter.GetComponent<weaponScript>().enabled == true)
				shooter.GetComponent<weaponScript>().enabled = false;
			else {
				shooter.GetComponent<weaponScript>().enabled = true;
			}
		}
	}
}
