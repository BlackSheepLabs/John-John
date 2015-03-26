using UnityEngine;
using System.Collections;

public class ControlsGUI : MonoBehaviour {
	/*
	 * Displays the controls for the player to view.
	 */

	public static bool controlsOn;
	Rect window;
	public GUISkin custSkin;

	// Use this for initialization
	void Start () {
		controlsOn = false;
		window = new Rect(Screen.width/8,Screen.height/16,
		                  Screen.width-(Screen.width/6 * 2),Screen.height-(Screen.height/8 * 2));
	}
	
	// Update is called once per frame
	void OnGUI () {
		if (controlsOn){
			GUI.skin = custSkin;
			GUI.Box (window,"Controls");

			GUI.Label(new Rect(Screen.width/6,Screen.height/7,Screen.width,Screen.height/20),
			          "Move Forward: W Key");
			GUI.Label(new Rect(Screen.width/6,Screen.height/7+40,Screen.width,Screen.height/20),
			          "Move Backward: S Key");
			GUI.Label(new Rect(Screen.width/6,Screen.height/7+80,Screen.width,Screen.height/20),
			          "Move Left: A Key");
			GUI.Label(new Rect(Screen.width/6,Screen.height/7+120,Screen.width,Screen.height/20),
			          "Move Right: D Key");
			GUI.Label(new Rect(Screen.width/6,Screen.height/7+160,Screen.width,Screen.height/20),
			          "Jump: Spacebar");
			GUI.Label(new Rect(Screen.width/6,Screen.height/7+200,Screen.width,Screen.height/20),
			          "Interact With Objects: Left Mouse Button");
			GUI.Label(new Rect(Screen.width/6,Screen.height/7+240,Screen.width,Screen.height/20),
			          "Switch Character: Right Mouse Button");
			GUI.Label(new Rect(Screen.width/6,Screen.height/7+280,Screen.width,Screen.height/20),
			          "Pause Game: P Key");
			GUI.Label(new Rect(Screen.width/6,Screen.height/7+320,Screen.width,Screen.height/20),
			          "Skip Level: F12 Key");
			//Back button
			if (GUI.Button(new Rect(Screen.width/7,Screen.height/1.35f,Screen.width/6,Screen.height/25),"Back")){
				OptionMenuGUI.optionsOn = !OptionMenuGUI.optionsOn;
				controlsOn = false;
			}
		}
	}
}
