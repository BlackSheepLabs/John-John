using UnityEngine;
using System.Collections;
//using UnityEditor;

public class CharacterDies : MonoBehaviour {

	public AudioSource music;	//Whatever object is playing the music
	public AudioSource deathSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		//Ensure that the colliding object is the player. Otherwise
		//Don't do jack.
		if (other.gameObject.tag == "Player"){
			//Play a death sound, like a scream or something
			//-----------Optional----------------
			//Have Camera zoom out. Would only work if we're using a
			//character model at some point.
			//-----------------------------------
			//Stop player movement. It doesn't appear to use a rigidbody
			//In CharacterMotor class, use variable 'canControl'
			//Only prob is that the script is in JavaScript

			//music.Stop();
			deathSound.Play ();
			StartCoroutine(waitBeforeReset());
			
		}
	}

	IEnumerator waitBeforeReset(){
		yield return new WaitForSeconds(1);
		//Load Screen?
		Application.LoadLevel(Application.loadedLevel);
	}
}
