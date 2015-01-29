using UnityEngine;
using System.Collections;

public class DeactivateWall : MonoBehaviour {
	enum ActivateState {ON, OFF}
	private ActivateState activateState;
	public GameObject explodeParticle;
	
	// Use this for initialization
	void Start () {
		activateState = ActivateState.OFF;
		
	}
	
	// Update is called once per frame
	void Update () {
		unrenderWall();
	}
	
	void ObjectActivate() {
		activateState = ActivateState.ON;
	}
	
	void ObjectDeactivate() {
		activateState = ActivateState.OFF;
	}

	void unrenderWall() {
		if(activateState == ActivateState.ON)
		{
			Instantiate(explodeParticle, new Vector3(transform.position.x + 1, 0, transform.position.z - 1), transform.rotation);
			gameObject.SetActive(false);
		}
	}
}
