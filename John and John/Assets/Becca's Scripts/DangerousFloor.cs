using UnityEngine;
using System.Collections;

public class DangerousFloor : MonoBehaviour {

	public DangerousFloorWarning warning;
	public static bool triggered = false;
	public bool instantDeath = false;

	// Use this for initialization
	void Start () {

		if(instantDeath == true)
			gameObject.renderer.material.color = Color.magenta;

		else
			gameObject.renderer.material.color = Color.yellow;

		warning.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void OnTriggerEnter()
	{
		
		if (instantDeath == false)
		{
			gameObject.renderer.material.color = Color.cyan;
			warning.enabled = true;
		}

		else
			Application.LoadLevel (Application.loadedLevel);

	}

	void OnTriggerExit()
	{
		gameObject.renderer.material.color = Color.magenta;
		warning.enabled = false;
		DangerousFloorWarning.levelReload = 5.0f;
		DangerousFloorWarning.levelTime = 0;


	}


}
