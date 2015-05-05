using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActivatePlatformOnTrigger : Trigger {

	public List<GameObject> movingPlatforms;
	public List<vp_MovingPlatform> vp_Plats;

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

		foreach(vp_MovingPlatform plat in vp_Plats)
			plat.SendMessage("GoTo", plat.TargetedWaypoint == 1, SendMessageOptions.DontRequireReceiver);
	}
	
	public override void Deactivate ()
	{
		foreach(GameObject plat in movingPlatforms)
			plat.GetComponent<vp_MovingPlatform>().enabled = false;

		foreach(vp_MovingPlatform plat in vp_Plats)
			plat.SendMessage("GoTo", plat.TargetedWaypoint == 0, SendMessageOptions.DontRequireReceiver);
	}

}
