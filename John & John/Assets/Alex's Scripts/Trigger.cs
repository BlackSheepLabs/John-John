// A generalized script for constructing kinematic trigger systems
//
// Written by: Alex Richard

using UnityEngine;
using System.Collections;

public enum Type {
	Clickable,		// Requires a trigger collider so that the player can find and toggle the object
	Touchable,
	KeyTest,
	NonInteractive
}

public class Trigger : MonoBehaviour {

	// The current state of this object
	public enum State {
		Activated,
		Activating,
		Deactivated,
		Deactivating
	}

	public enum Locality {
		World,
		ThisObject,
		ResponseObject
	}

	State currentState = State.Deactivated;
	public State state { get { return currentState; } }

	public Type triggerType = Type.NonInteractive;

	public Trigger[] responseTriggers;

	public GameObject responseObject;

	// The duration over which to move the response object
	// Acts to delay activation signals if no response object is set
	public float duration;
	float moveTime;

	// Animation curves disctating how to move an object
	public AnimationCurve xMovement;
	public AnimationCurve yMovement;
	public AnimationCurve zMovement;

	public bool Toggleable = true;
	public bool forceResponseToSameState = false;

	Vector3 initialPosition;

	// The space in which to move the response object if one is set
	public Locality movementReferenceFrame;

	public virtual void Start()
	{
		if (responseObject != null)
		{
			switch(movementReferenceFrame)
			{
				case Locality.World:
					initialPosition = responseObject.transform.position;
					break;
				case Locality.ResponseObject:
					initialPosition = responseObject.transform.localPosition;
					break;
				case Locality.ThisObject:
					initialPosition = responseObject.transform.position - transform.position;
					break;
			}
		}
	}


	public virtual void Update() 
	{
		switch(currentState)
		{
			case State.Deactivating:
				if(moveTime >= duration)
				{
					currentState = State.Deactivated;
					foreach(Trigger t in responseTriggers) t.Deactivate();
				}
				else if(responseObject != null)
				{
					float adjTime = moveTime / duration;
					switch(movementReferenceFrame)
					{
					case Locality.World:
						responseObject.transform.position = initialPosition + xMovement.Evaluate(adjTime) * Vector3.right
							+ yMovement.Evaluate(adjTime) * Vector3.up + zMovement.Evaluate(adjTime) * Vector3.forward;
						break;
					case Locality.ResponseObject:
						responseObject.transform.position = initialPosition + xMovement.Evaluate(adjTime) * responseObject.transform.right
							+ yMovement.Evaluate(adjTime) * responseObject.transform.up + zMovement.Evaluate(adjTime) * responseObject.transform.forward;
						break;
					case Locality.ThisObject:
						responseObject.transform.position = initialPosition + xMovement.Evaluate(adjTime) * transform.right
							+ yMovement.Evaluate(adjTime) * transform.up + zMovement.Evaluate(adjTime) * transform.forward;
						break;
					}
				}
				break;
			case State.Activating:
				if(moveTime >= duration)
				{
					currentState = State.Activated;
					foreach(Trigger t in responseTriggers) t.Activate();
				}
				else if(responseObject != null)
				{
					float adjTime = moveTime / duration;
					switch(movementReferenceFrame)
					{
					case Locality.World:
						responseObject.transform.position = initialPosition + xMovement.Evaluate(adjTime) * Vector3.right
							+ yMovement.Evaluate(adjTime) * Vector3.up + zMovement.Evaluate(adjTime) * Vector3.forward;
						break;
					case Locality.ResponseObject:
						responseObject.transform.position = initialPosition + xMovement.Evaluate(adjTime) * responseObject.transform.right
							+ yMovement.Evaluate(adjTime) * responseObject.transform.up + zMovement.Evaluate(adjTime) * responseObject.transform.forward;
						break;
					case Locality.ThisObject:
						responseObject.transform.position = initialPosition + xMovement.Evaluate(adjTime) * transform.right
							+ yMovement.Evaluate(adjTime) * transform.up + zMovement.Evaluate(adjTime) * transform.forward;
						break;
					}
				}
				break;
			case State.Activated:
				if(forceResponseToSameState)
					foreach(Trigger t in responseTriggers)
						if(t.state == State.Deactivated) t.Activate();
				break;
			case State.Deactivated:
				if(forceResponseToSameState)
					foreach(Trigger t in responseTriggers)
						if(t.state == State.Activated) t.Deactivate();
				break;
		}

		if (triggerType == Type.KeyTest && Input.GetKeyDown (KeyCode.Space)) 
		{
			Activate ();
			Deactivate ();
		}
	}


	public void Activate() 
	{
		if (currentState == State.Deactivated) 
		{
			currentState = State.Activating;
			moveTime = 0.0f;
			OnActivate ();
		}
	}

	public virtual void OnActivate() {}

	
	public void Deactivate() 
	{
		if (Toggleable && currentState == State.Activated) 
		{
			currentState = State.Deactivating;
			moveTime = 0.0f;
			OnDeactivate ();
		}
	}

	public virtual void OnDeactivate() {}
}
