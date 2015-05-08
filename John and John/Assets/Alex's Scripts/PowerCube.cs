using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerCube : Trigger {

	private List<PowerCube> adjCubes;
	public bool IsAlwaysActive = false;

	public bool IsActive
	{get {return this.currentState == State.Activated;} }

	private bool containsMain = false;
	private Vector3 startPosition;
	private Quaternion startRotation;


	// Use this for initialization
	void Awake () {
		triggerType = TriggerType.NonInteractive;
		responseObject = null;
		adjCubes = new List<PowerCube>();
		duration = 1.0f;
		startPosition = this.transform.localPosition;
		startRotation = this.transform.localRotation;
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



	public Vector3 getInitialPosition(){
		return startPosition;
	}

	public Quaternion getInitialRotation(){
		return startRotation;
	}

	public void Reset(){
		this.transform.localPosition = getInitialPosition();;

	}

	public void CheckSources()
	{
		bool powered = false;


		foreach(PowerCube p in adjCubes){
			if(p.IsActive && p.containsMain) powered = true;
		}

		if(powered && !IsActive)
			Activate ();
		else if(!powered && IsActive)
			Deactivate ();
	}

	public override void OnActivated ()
	{
		foreach(PowerCube p in adjCubes)
			p.Activate ();
	}

	public override void OnDeactivated ()
	{
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
			adjCubes.Add (pC);

			if(pC.tag == "MainCube" || this.tag == "MainCube"){
				containsMain = true;
				foreach(PowerCube p in adjCubes)
					p.CheckSources();
			}

			if(pC.IsActive && !this.IsActive && containsMain)
				Activate ();
		}
	}

	void OnTriggerExit(Collider other)
	{
		PowerCube pC = other.GetComponent<PowerCube>();
		if(pC != null)
		{
			adjCubes.Remove (pC);
			if(pC.tag == "MainCube"){
				containsMain = false;
				foreach(PowerCube p in adjCubes)
					p.CheckSources();
			}
			CheckSources();
		}
	}
}
