using UnityEngine;
using System.Collections;

public class RaiseStairsOnButton : MonoBehaviour {
	enum StairState {UP, DELAYING, DOWN}

	
	public float movementTime = 2f;
	public Vector3 movementVector;
	
	private StairState stairState;
	private Vector3 startPosition;
	private float timer = 0f;
	private float delayTimer = 6f;

	// Use this for initialization
	void Start () {
		stairState = StairState.DOWN;
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (stairState == StairState.UP && timer <= movementTime) {
			timer += Time.deltaTime;
		} else if (stairState == StairState.DOWN && timer >= 0) {
			timer -= Time.deltaTime;
		}
		
		transform.position = Vector3.Lerp(startPosition, startPosition + movementVector, timer/movementTime);
		
		if (stairState == StairState.DELAYING) {
			delayTimer -= Time.deltaTime;
			if (delayTimer <= 0) {
				stairState = StairState.DOWN;
			}
		}
	}

	void ObjectActivate ()
	{
		
		stairState = StairState.UP;
	}
	
	void ObjectDeactivate ()
	{
		stairState = StairState.DOWN;
	}
}
