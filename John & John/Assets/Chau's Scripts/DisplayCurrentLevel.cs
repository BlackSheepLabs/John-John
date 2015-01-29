using UnityEngine;
using System.Collections;

public class DisplayCurrentLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUI.Label(new Rect(100, 0, 50, 50), (gameManager.level).ToString());
	}
}
