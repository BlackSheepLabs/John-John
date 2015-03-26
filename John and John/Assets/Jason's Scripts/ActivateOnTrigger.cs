using UnityEngine;
using System.Collections;

public class ActivateOnTrigger : MonoBehaviour {

	public bool activate;
	public bool destroyAfterActivation;

	public GameObject[] activatingObjects;

	// Use this for initialization
	void Start () {
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			foreach (GameObject obj in activatingObjects) {
				if (activate) {
					obj.SendMessage("ObjectActivate", SendMessageOptions.DontRequireReceiver);
				}
				else {
					obj.SendMessage("ObjectDeactivate", SendMessageOptions.DontRequireReceiver);
				}



			}
			if (destroyAfterActivation)
				Destroy(gameObject);
		}
	}

}

