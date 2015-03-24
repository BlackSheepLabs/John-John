using UnityEngine;
using System.Collections;

//save script for autosaving on level start
public class AutoSaveAtLevelStart : MonoBehaviour {
	

	private int level;

	// Use this for initialization
	void Start () {
		level = Application.loadedLevel;
		PlayerPrefs.SetInt ("CurrentLevel", level);
		Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
