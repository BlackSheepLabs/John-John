using UnityEngine;
using System.Collections;

public class KillTheClone : MonoBehaviour {

	private bool active = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void Kill() {
		active = true;
	}

	void OnTriggerEnter(Collider other) {

		if (other.tag == "Player" && active) {
			AutoFade.LoadLevel(Application.loadedLevel + 1, 2f, 2f, Color.black);
			Debug.Log("Load Level");
		}
	}
}
