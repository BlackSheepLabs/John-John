using UnityEngine;
using System.Collections;

public class InsertPushable : MonoBehaviour {

	/*An array of Gameobjects that you need to be activated*/
	public GameObject[] activatableObjects;


	void OnTriggerEnter(Collider other){
		/*If object inserted has tag "Pushable", call ObjectActivate function*/
		if(other.tag == "Pushable")
			ObjectActivate();

	}

	void ObjectActivate() {
		/*Activate all objects set to be activated*/
			if (activatableObjects.Length != 0) {
				foreach (GameObject obj in activatableObjects) {
					obj.SendMessage("ObjectActivate", SendMessageOptions.DontRequireReceiver);
				}
		}
		
	}
}
