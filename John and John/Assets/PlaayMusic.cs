using UnityEngine;
using System.Collections;

public class PlaayMusic : MonoBehaviour {

	public GameObject Music;
	// Use this for initialization
	void Start () {



	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (this.audio.isPlaying == false) {
			Music.SetActive(true);
		}
	}
}
