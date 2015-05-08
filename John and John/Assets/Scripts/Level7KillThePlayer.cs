using UnityEngine;
using System.Collections;

public class Level7KillThePlayer : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider col) {
		Debug.Log("WTF");
		if (col.collider.tag == "Player") {
		player.GetComponent<vp_FPPlayerDamageHandler>().Die();
		AutoFade.LoadLevel(Application.loadedLevel + 1, 2f, 2f, Color.black);

		}
	}
}
