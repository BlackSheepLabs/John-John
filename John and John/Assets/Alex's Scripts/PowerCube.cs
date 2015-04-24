using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerCube : Trigger {

	private List<PowerCube> adjCubes;
	public bool IsAlwaysActive = false;

	public bool IsActive
	{get {return this.currentState == State.Activated;} }

	// Use this for initialization
	void Awake () {
		triggerType = TriggerType.NonInteractive;
		responseObject = null;
		adjCubes = new List<PowerCube>();
		duration = 1.0f;
		if(IsAlwaysActive)
		{
			this.currentState = State.Activated;
			this.renderer.material.SetColor("_CubeColor",Color.green);
			this.Toggleable = false;
		}
		else
		{
			this.currentState = State.Deactivated;
			this.renderer.material.SetColor("_CubeColor",Color.red);
			this.Toggleable = true;
			duration = 1.0f;
		}
	}

	public void CheckSources()
	{
		bool powered = false;


		foreach(PowerCube p in adjCubes)
			if(p.IsActive) powered = true;

		if(powered && !IsActive)
			Activate ();
		else if(!powered && IsActive)
			Deactivate ();
	}

	public override void OnActivated ()
	{
		Debug.Log ("Cube on!");
		foreach(PowerCube p in adjCubes)
			p.Activate ();
	}

	public override void OnDeactivated ()
	{
		Debug.Log ("Cube off!");
		foreach(PowerCube p in adjCubes)
			p.CheckSources ();
	}

	public override void OnActivating(float adjTime)
	{
		this.renderer.material.SetColor("_CubeColor",Color.green*adjTime + (1-adjTime)*Color.red);
	}

	public override void OnDeactivating(float adjTime)
	{
		this.renderer.material.SetColor("_CubeColor",Color.red*adjTime + (1-adjTime)*Color.green);
	}

	void OnTriggerEnter(Collider other)
	{
		PowerCube pC = other.GetComponent<PowerCube>();
		if(pC != null && pC != this)
		{
			Debug.Log ("Found Power Cube!");
			adjCubes.Add (pC);
			if(pC.IsActive && !this.IsActive)
				Activate ();
		}
	}

	void OnTriggerExit(Collider other)
	{
		PowerCube pC = other.GetComponent<PowerCube>();
		if(pC != null)
		{
			Debug.Log ("Bye Power Cube!");
			adjCubes.Remove (pC);
			CheckSources();
		}
	}
}
