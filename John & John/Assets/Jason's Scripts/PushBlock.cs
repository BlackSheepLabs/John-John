using UnityEngine;
using System.Collections;

/* Script to attach to player so he can push pushable blocks.
 * 
 * Game Object Requirements:
 * 	Should be attached to the player
 * 
 * Block Requirements:
 * 	Pushable blocks should contain the tag "Pushable"
 * 
 * Field Requirements:
 * 	User should enter the push power the character should have.
 * 
 * Steps:
 * 
 */
public class PushBlock : MonoBehaviour {
	public float pushPower = 1f;
	Vector3 pushDirection;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnControllerColliderHit(ControllerColliderHit other)
	{

		if (other.collider.tag == "Pushable")
		{
			Rigidbody body = other.collider.attachedRigidbody;
			if (body == null || body.isKinematic)
				return;

			if (other.moveDirection.y < -0.3f)
				return;

			other.rigidbody.freezeRotation = true;

			if (Mathf.Abs(other.moveDirection.z) > Mathf.Abs(other.moveDirection.x)) {
				pushDirection = new Vector3(0, 0, other.moveDirection.z);
			} else {
				pushDirection = new Vector3(other.moveDirection.x, 0, 0);
			}

			body.velocity = pushDirection * pushPower;
			//Debug.Log(other.moveDirection.x + ": X");
			//Debug.Log(other.moveDirection.z + ": Z");
		}
	}
}
