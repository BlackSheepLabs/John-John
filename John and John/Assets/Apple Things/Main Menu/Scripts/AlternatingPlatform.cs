using UnityEngine;
using System.Collections;

public class AlternatingPlatform : MonoBehaviour {

	public float time;

	// Use this for initialization
	void Start () {
		StartCoroutine(alternate(time));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator alternate(float time){
		yield return new WaitForSeconds(time);
		gameObject.renderer.enabled = !gameObject.renderer.enabled;
		gameObject.collider.enabled = !gameObject.collider.enabled;
		StartCoroutine(alternate(time));
	}
}
