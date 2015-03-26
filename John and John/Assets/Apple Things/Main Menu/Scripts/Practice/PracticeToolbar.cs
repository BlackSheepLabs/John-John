using UnityEngine;
using System.Collections;

public class PracticeToolbar : MonoBehaviour {

	private int toolbarInt = 0;
	private string [] toolbarStrings = {"P1", "P2", "P3"};

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		toolbarInt = GUI.Toolbar(new Rect(25,150,250,30),toolbarInt,toolbarStrings);
		GUI.Label(new Rect(350,155,50,50),toolbarStrings[toolbarInt]);
	}
}
