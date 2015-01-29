using UnityEngine;
using System.Collections;

/* Script to attach to platforms that will move when activated
 * 
 * Game Object Requirements:
 * 	Script should be attached to a plane-like platform that can be jumped on and move when it's activated
 * 
 * Field Requirements:
 * 	User needs to indicate which direction the platform is supposed to move.  To do this, alter the movement
 *  vector, with x making it move in the x direction, etc.  Higher value = higher speed.
 * 	User must enter the amount of time the platform should move for.  This will directly affect the distance traveled.
 * 
 * Steps:
 * 	Uhh...
 */
public class MovingPlatform_Perpetual : MonoBehaviour
{
		enum ActivateState
		{
				ON,
				OFF
		}
	
		public Vector3 movementVector;
		public float movementTime = 2.0f;
		public Material onMaterial;
		public Material offMaterial;
		private Vector3 startPosition;
		private bool reverse;
		public bool stopAtEnd;
		private ActivateState activateState;
	
		// Use this for initialization
		void Start ()
		{
				activateState = ActivateState.ON;
				startPosition = transform.position;
				StartCoroutine (MoveOverTime ());
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
	
		void ObjectActivate ()
		{
				activateState = ActivateState.ON;
				gameObject.renderer.material = onMaterial;
		}
	
		void ObjectDeactivate ()
		{
				activateState = ActivateState.OFF;
				gameObject.renderer.material = offMaterial;
		}
	
		IEnumerator MoveOverTime ()
		{
				float timer = 0;
		
				while (true) {
						if (activateState == ActivateState.ON) {
								if (!reverse) {
										timer += Time.deltaTime;
								} else {
										timer -= Time.deltaTime;
								}

								if (!stopAtEnd) {
				
										//Loop the timer
										if (timer > movementTime) {
												reverse = true;
										} else if (timer < 0) {
												reverse = false;
										}
								} else {
										if (timer > movementTime) {
												ObjectDeactivate ();
												reverse = true;
										} else if (timer < 0) {
												ObjectDeactivate ();
												reverse = false;
										}
										//movementVector = - movementVector;
								}
				
								//Returns the start position at 0, the to position at 1, and in between in between.
								transform.position = Vector3.Lerp (startPosition, startPosition + movementVector, timer / movementTime);
				
						}
						yield return null;
				}
		}
}
