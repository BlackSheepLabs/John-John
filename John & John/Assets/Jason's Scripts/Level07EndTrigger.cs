using UnityEngine;
using System.Collections;

/* Trigger that goes at the end of Level 7
 * Put on the trigger field at the beginning of the end room
 * Wipes out all remaining bullets
 * Sends activation to clone to activate kill script 
 */
public class Level07EndTrigger : MonoBehaviour {

	public GameObject[] cannons;
	public GameObject clone;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter() {
		foreach (GameObject cannon in cannons) {
			cannon.SetActive(false);
		}
		clone.SendMessage("Kill", SendMessageOptions.DontRequireReceiver);
	}
}
