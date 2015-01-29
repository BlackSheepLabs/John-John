using UnityEngine;
using System.Collections;

public class Load : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if(GUI.Button(new Rect(0, 100, 50, 50), "Load"))
		{
			Application.LoadLevel(PlayerPrefs.GetInt ("CurrentLevel"));
		}
	}
}
