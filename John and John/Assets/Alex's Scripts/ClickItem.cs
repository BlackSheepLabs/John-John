using UnityEngine;
using System.Collections;

public class ClickItem : MonoBehaviour {
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			RaycastHit obj;

			if(Physics.Raycast(transform.position+transform.forward*0.5f, transform.forward,out obj,1.0f))
			{
				Trigger t = obj.collider.GetComponent<Trigger>();

				Debug.Log("Trying to click " + obj.collider.name + "...");

				if(t != null && t.triggerType == TriggerType.Clickable)
				{
					if(t.state == State.Activated)
						t.Deactivate();
					else
						t.Activate();
				}
			}
		}
	}
}
