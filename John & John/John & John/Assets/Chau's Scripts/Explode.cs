using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {
	enum ActivateState {ON, OFF}

	private ActivateState activateState;
	public GameObject explodeParticle;

	// Use this for initialization
	void Start () {
		activateState = ActivateState.OFF;

	
	}
	
	// Update is called once per frame
	void Update () {
		explode();
	}

	void ObjectActivate() {
		activateState = ActivateState.ON;
	}

	void ObjectDeactivate() {
		activateState = ActivateState.OFF;
	}

	void explode() {
		//throw in fancy explosion effects later

		if(activateState == ActivateState.ON)
		{
			Instantiate(explodeParticle, transform.position, transform.rotation);
			Destroy(gameObject);
		}


	}
}
