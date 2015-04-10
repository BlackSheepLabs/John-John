using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {


	// Use this for initialization
	void Start () {


		Time.timeScale = 1;
		Application.LoadLevel(Application.loadedLevelName);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
