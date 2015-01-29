using UnityEngine;
using System.Collections;

/* Script to attach to trigger on the floor of a pit which will raise a staircase
 * 
 * Game Object Requirements:
 * 	Script should be attached to a trigger resting on the floor
 * 
 * Field Requirements:
 * 	User must indicate which staircase should be associated with this script
 *  User must indicate the height of the staircase
 * 
 * Steps:
 * 	Uhh...
 * 
 */

public class RaiseStairsOnTrigger : MonoBehaviour {
	enum StairState {UP, DELAYING, DOWN}

	public GameObject staircase;

	public float movementTime = 2f;
	public Vector3 movementVector;

	private StairState stairState;
	private Vector3 startPosition;
	private float timer = 0f;
	private float delayTimer = 6f;

	// Use this for initialization
	void Start () {
		stairState = StairState.DOWN;
		startPosition = staircase.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (stairState == StairState.UP && timer <= movementTime) {
			timer += Time.deltaTime;
		} else if (stairState == StairState.DOWN && timer >= 0) {
			timer -= Time.deltaTime;
		}

		staircase.transform.position = Vector3.Lerp(startPosition, startPosition + movementVector, timer/movementTime);
	
		if (stairState == StairState.DELAYING) {
			delayTimer -= Time.deltaTime;
			if (delayTimer <= 0) {
				stairState = StairState.DOWN;
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			stairState = StairState.UP;
			delayTimer = 6f;

			Debug.Log ("Things happened");
		}

	}

	void OnTriggerExit(Collider other) {
		if (other.CompareTag("Player")) {
			stairState = StairState.DELAYING;
			Debug.Log("Things unhappened");
		}
	}
}
