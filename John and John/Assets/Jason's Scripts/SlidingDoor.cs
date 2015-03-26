using UnityEngine;
using System.Collections;

/* Script to attach to door panels that should slide open and closed
 * 
 * Game Object Requirements:
 * 	Script should be attached to a door pane like object in a doorway.
 * 
 * Field Requirements:
 * 	User must indicate whether it should slide horizontally or vertically.
 * 	Use horizontal if there is a room above and space to the side.  Use vertical otherwise.
 * 
 * Steps:
 * 	Uhh...
 * 
 */
public class SlidingDoor : MonoBehaviour {
	enum DoorState {OPEN, SHUT}
	enum MovementState {HORIZONTAL, VERTICAL}

	public float movementTime = 1f;
	public bool moveHorizontal = false;

	private MovementState movementType;
	private DoorState doorState;
	public Vector3 movementVector;
	private Vector3 startPosition;
	private float timer = 0f;

	public AudioClip doorSound;

	// Set out states and starting position
	void Start () {
		doorState = DoorState.SHUT;
		startPosition = transform.position;

		if (moveHorizontal) {
			movementType = MovementState.HORIZONTAL;
		} else {
			movementType = MovementState.VERTICAL;
		}

		//StartCoroutine(MovementOverTime());
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(doorState);


		

		if (doorState == DoorState.OPEN && (timer < movementTime)) {
			timer += Time.deltaTime;
		} else if (doorState == DoorState.SHUT && timer > 0) {
			timer -= Time.deltaTime;
		}
		
		transform.position = Vector3.Lerp(startPosition, startPosition + movementVector, timer/movementTime);
		
		//Debug.Log(timer);
	}

	void ObjectActivate() {
		doorState = DoorState.OPEN;
		audio.PlayOneShot(doorSound,1); // need to check and see if this is in the right place
	}
	
	void ObjectDeactivate() {
		doorState = DoorState.SHUT;
	}

}
