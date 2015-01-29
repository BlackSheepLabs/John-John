using UnityEngine;
using System.Collections;

public class GoToNextLvl : MonoBehaviour {

	public GameObject player;
	public GameObject clone;

	bool playerIn1;
	bool playerIn2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (playerIn1 && playerIn2)
			AutoFade.LoadLevel( Application.loadedLevel + 1,3,1,Color.black);
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player")
			if (playerIn1 == false) playerIn1 = true;
		else if (playerIn1 == true) playerIn2 = true;
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Player")
			if (playerIn2 == true) playerIn2 = false;
		else if (playerIn1 == true) playerIn1 = false;
	}
}
