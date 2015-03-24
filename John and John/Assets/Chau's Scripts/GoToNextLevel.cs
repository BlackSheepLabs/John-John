using UnityEngine;
using System.Collections;


//Personal Script for testing purposes only
public class GoToNextLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI()
	{
		if(GUI.Button(new Rect(0, 50, 50, 50), "Advance"))
		{
			gameManager.level += 1;
			Application.LoadLevel(gameManager.level);


		}

	}
}
