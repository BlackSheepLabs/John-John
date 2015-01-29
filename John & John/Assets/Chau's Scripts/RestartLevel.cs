using UnityEngine;
using System.Collections;

public class RestartLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI()
	{
		if(GUI.Button(new Rect(0, 200, 50, 50), "Restart"))
		{
			Application.LoadLevel(Application.loadedLevel);
			
			
		}
	}
}
