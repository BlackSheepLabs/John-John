using UnityEngine;
using System.Collections;

public class PracticeTextArea : MonoBehaviour {

	private string textFieldString = "Text Field";
	private string textAreaStr = "Text Area";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		textFieldString = GUI.TextField(new Rect(50,500,100,30),textFieldString,25);
		GUI.Label(new Rect(160,500,100,100),textFieldString);
		textAreaStr = GUI.TextArea(new Rect(230,450,100,100),textAreaStr,250);
	}
}
