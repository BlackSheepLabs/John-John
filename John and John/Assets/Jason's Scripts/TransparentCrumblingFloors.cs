using UnityEngine;
using System.Collections;

/* Script to attach to a Crumbling Floor tile
 *
 * Crumbling floor will disintegrate after the player has stood on it for a while
 * Modified to be used for platforms with transparency
 * 
 * Game Object Requirement:
 * 	This goes on the glass center piece of the platform.
 *  That glass pane needs a collision box that is a trigger
 * 
 * Field Requirements:
 * 	User needs to enter the amount of time (in seconds) it will take for the floor to fully crumble.
 *  User needs to enter type of crumble they would like.  Types are:
 * 		0: Crumble constantly until gone as soon as touched
 * 		1: Start crumbling when player steps on it, but stop when player leaves trigger
 * 		2: Start crumbling when player steps on it, but reset when player leaves trigger
 * 		3: Crumble constantly until gone as soon as touched, but can be brought back when the player 
 * 			presses a button.
 * 
 * Steps:
 * 	Player steps on floor to collide.
 * 	Check for other.tag with player tag.
 *  Change state to reflect being stepped on.
 *  Update to constantly draw from the timer.
 * 
 */
public class TransparentCrumblingFloors : MonoBehaviour {
	enum CrumbleState {CRUMBLING, SAFE}
	enum CrumbleType {CONSTANT, ONOFF, RESPAWN}
	
	public float timer = 3.0f;
	public float respawnTimer = 5.0f;
	public int type = 1;
	
	public AudioClip snapSound;
	
	private float blueValue = .75f;
	private float blueScale;
	private CrumbleState crumbleState;
	private CrumbleType crumbleType;
	private float timerMax;
	private float respawnTimerMax;

	//Hold the original texture's color
	private float origR, origG, origB;
	
	// Use this for initialization
	void Start () {
		crumbleState = CrumbleState.SAFE;
		
		switch (type) {
		case 0:
			crumbleType = CrumbleType.CONSTANT;
			break;
		case 1:
			crumbleType = CrumbleType.ONOFF;
			break;
		case 2:
			crumbleType = CrumbleType.RESPAWN;
			break;
		default:
			crumbleType = CrumbleType.ONOFF;
			break;
		}
		
		//BlueScale provides the scale to multiply timer by to provide the new blue value
		blueScale = blueValue / timer;

		//Set the color to the original's color
		origB = gameObject.renderer.material.color.b;
		origG = gameObject.renderer.material.color.g;
		origR = gameObject.renderer.material.color.r;
		
		timerMax = timer;
		respawnTimerMax = respawnTimer;
	}
	
	// Update is called once per frame
	void Update () {
		if (crumbleState == CrumbleState.CRUMBLING) {
			UpdateCrumbling ();
		} else if (crumbleState == CrumbleState.SAFE) {
			
			UpdateSafe();
		}
		
		//Change colors based on state
		blueValue = timer * blueScale;

		gameObject.renderer.material.color = new Color(origR, origG, origB, blueValue);

		/* Old method
		if (crumbleType == CrumbleType.CONSTANT) {
			gameObject.renderer.material.color = new Color(0, 0, blueValue);
		} else if (crumbleType == CrumbleType.ONOFF) {
			gameObject.renderer.material.color = new Color(0, blueValue, blueValue);
		} else if (crumbleType == CrumbleType.RESPAWN) {
			gameObject.renderer.material.color = new Color(blueValue, blueValue, 0);
		} */

		if (timer <= 0) {
			audio.PlayOneShot(snapSound,1);
			renderer.enabled = false;
			collider.enabled = false;
			//Disable sibling renderers
			transform.parent.Find("Edges_Cylinder_Material.005").transform.renderer.enabled = false;
			transform.parent.Find("Sphere_Sphere_Material.006").transform.renderer.enabled = false;

			transform.parent.collider.enabled = false;
			crumbleState = CrumbleState.SAFE;
			
			if (crumbleType == CrumbleType.RESPAWN) {
				respawnTimer -= Time.deltaTime;
				if (respawnTimer <= 0) {
					renderer.enabled = true;
					collider.enabled = true;
					transform.parent.Find("Edges_Cylinder_Material.005").transform.renderer.enabled = true;
					transform.parent.Find("Sphere_Sphere_Material.006").transform.renderer.enabled = true;
					transform.parent.collider.enabled = true;
					timer = timerMax;
					respawnTimer = respawnTimerMax;
				}
			}
		}
	}	
	void UpdateCrumbling() {
		timer -= Time.deltaTime;
		
		
		//Debug.Log(blueValue);
	}
	void UpdateSafe() {
		/*if (crumbleType == CrumbleType.RESPAWN) {
			if (timer < timerMax) {
				timer += Time.deltaTime;
			}
		}*/
	}
	
	
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			crumbleState = CrumbleState.CRUMBLING;
		}
	}
	
	void OnTriggerExit(Collider other) {
		if (other.tag == "Player") {
			if (crumbleType == CrumbleType.CONSTANT) {
				//Do nothing.  Keeps crumbling.
			}
			if (crumbleType == CrumbleType.ONOFF) {
				crumbleState = CrumbleState.SAFE;
			}
			if (crumbleType == CrumbleType.RESPAWN) {
				//crumbleState = CrumbleState.SAFE;
			}
		}
	}
}
