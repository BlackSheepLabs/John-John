using UnityEngine;
using System.Collections;

public class PlayNarratorOnTrigger : MonoBehaviour {
	public AudioClip narration;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {


			audio.clip = narration;
			audio.Play();
		}
	}
}
