using UnityEngine;
using System.Collections;

/* In order to make newlines for the string that you enter into the inspector type out your string 
	in the format that you want it to appear in notepad then copy and paste that into the string
	in the inspector
 */

public class WhiteboardTrigger : MonoBehaviour {
	enum boardState{ON, OFF};

	public string text;

	private boardState whiteboardState;

	public GUISkin custSkin;

	public GameObject characterSwap;
	

	// Use this for initialization
	void Start () {
		whiteboardState = boardState.OFF;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other) {
		Debug.Log("Entered Trigger");
		if (other.tag == "Player") {
			whiteboardState = boardState.ON;
			characterSwap.SetActive(false);
		}
		
	}
	
	void OnTriggerExit(Collider other) {
		if (other.CompareTag("Player")) {
			whiteboardState = boardState.OFF;
			characterSwap.SetActive (true);
		}
	}

	void OnGUI()
	{

		GUI.skin = custSkin;
		if(whiteboardState == boardState.ON)
		{
			GUI.Box (new Rect (((Screen.width - 600)/2), ((Screen.height - 400)/2), 600, 400), text);
		}
	}
}
