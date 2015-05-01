using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActivatePlatformOnTrigger : Trigger {

	public List<GameObject> movingPlatforms;

	public bool IsActive
	{get {return this.currentState == State.Activated;} }
	// Use this for initialization
	void Awake () {
		responseObject = null;
		duration = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Activate ()
	{
		foreach(GameObject plat in movingPlatforms)
			plat.GetComponent<vp_MovingPlatform>().enabled = true;
	}
	
	public override void Deactivate ()
	{
		foreach(GameObject plat in movingPlatforms)
			plat.GetComponent<vp_MovingPlatform>().enabled = false;
	}

}
