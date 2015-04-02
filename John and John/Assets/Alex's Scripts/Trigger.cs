// A generalized script for constructing kinematic trigger systems
//
// Written by: Alex Richard

using UnityEngine;
using System.Collections;

public enum TriggerType {
	Clickable,		// Requires a trigger collider so that the player can find and toggle the object
	Touchable,
	KeyTest,
	NonInteractive
}

// The current state of this object
public enum State {
	Activated,
	Activating,
	Deactivated,
	Deactivating
}

public class Trigger : MonoBehaviour {

	public enum Locality {
		World,
		ThisObject,
		ResponseObject
	}


	public State currentState = State.Deactivated;
	public State state { get { return currentState; } }

	[Space(10)][Header("Trigger Settings")][Space(5)]

	public TriggerType triggerType = TriggerType.NonInteractive;

	public Trigger[] responseTriggers;

	public LayerMask layers = -1;
	private int triggeredObjects = 0;

	[Space(10)][Header("Movement References")][Space(5)]

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

	private Vector3 initialPosition;

	private AudioSource source;

	// The space in which to move the response object if one is set
	public Locality movementReferenceFrame;

	// Handles loading and playing sound effects on activate/deactivate
	[Space(10)][Header("Sound Effects")][Space(5)]

	public AudioClip activateSoundEffect;
	public float activateSEDelay = 0.0f;
	public AudioClip deactivateSoundEffect;
	public float deactivateSEDelay = 0.0f;

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

		source = gameObject.GetComponent<AudioSource>();

		if(source == null) 
		{
			source = gameObject.AddComponent<AudioSource>();
			source.playOnAwake = false;
		}
	}


	public virtual void Update() 
	{
		switch(currentState)
		{
			case State.Deactivating:
				moveTime += Time.deltaTime;
				if(moveTime >= duration)
				{
					currentState = State.Deactivated;
					if(source != null && source.isPlaying && source.loop) source.Stop();
					foreach(Trigger t in responseTriggers) t.Deactivate();
				}
				else if(responseObject != null)
				{
					float adjTime = (duration - moveTime) / duration;
					switch(movementReferenceFrame)
					{
					case Locality.World:
						responseObject.transform.position = initialPosition + xMovement.Evaluate(adjTime) * Vector3.right
							+ yMovement.Evaluate(adjTime) * Vector3.up + zMovement.Evaluate(adjTime) * Vector3.forward;
						break;
					case Locality.ResponseObject:
						responseObject.transform.localPosition = initialPosition + xMovement.Evaluate(adjTime) * responseObject.transform.right
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
					if(source != null && source.isPlaying && source.loop) source.Stop();
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
						responseObject.transform.localPosition = initialPosition + xMovement.Evaluate(adjTime) * responseObject.transform.right
							+ yMovement.Evaluate(adjTime) * responseObject.transform.up + zMovement.Evaluate(adjTime) * responseObject.transform.forward;
						break;
					case Locality.ThisObject:
						responseObject.transform.position = initialPosition + xMovement.Evaluate(adjTime) * transform.right
							+ yMovement.Evaluate(adjTime) * transform.up + zMovement.Evaluate(adjTime) * transform.forward;
						break;
					}
				}
				moveTime += Time.deltaTime;
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

		if (triggerType == TriggerType.KeyTest && Input.GetKeyDown (KeyCode.E)) 
		{
			Activate ();
			Deactivate ();
		}
	}


	public virtual void Activate() 
	{

		if (currentState == State.Deactivated) 
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

			currentState = State.Activating;
			moveTime = 0.0f;

			if(source != null && activateSoundEffect != null) 
			{
				source.clip = activateSoundEffect;
				source.PlayDelayed (activateSEDelay);
			}
			else if(source != null && deactivateSoundEffect != null) 
			{
				source.clip = deactivateSoundEffect;
				source.PlayDelayed (deactivateSEDelay);
			}

			OnActivate ();
		}
	}

	public virtual void OnActivate() {}

	
	public virtual void Deactivate() 
	{
		if (Toggleable && currentState == State.Activated) 
		{
			currentState = State.Deactivating;
			moveTime = 0.0f;

			if(source != null && deactivateSoundEffect != null) 
			{
				source.clip = deactivateSoundEffect;
				source.PlayDelayed (deactivateSEDelay);
			}
			else if(source != null && activateSoundEffect != null) 
			{
				source.clip = activateSoundEffect;
				source.PlayDelayed (activateSEDelay);
			}

			OnDeactivate ();
		}
	}

	public virtual void OnDeactivate() {}

	public void OnTriggerEnter(Collider other)
	{
		if(triggerType == TriggerType.Touchable && (layers & (1 << other.gameObject.layer)) == 1)
		{
			triggeredObjects += 1;
			if(triggeredObjects == 1)
			{
				Activate ();
			}
		}
	}

	public void OnTriggerExit(Collider other)
	{
		if(triggerType == TriggerType.Touchable && (layers & (1 << other.gameObject.layer)) == 1)
		{
			triggeredObjects -= 1;
			if(triggeredObjects == 0)
			{
				Deactivate ();
			}
		}
	}
}
