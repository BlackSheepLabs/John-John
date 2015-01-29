using UnityEngine;
using System.Collections;

public class PracticeGUILayout : MonoBehaviour {

	private float sliderValue = 1.0f;
	private float maxSliderValue = 10.0f;
	public GUISkin custSkin;

	void OnGUI () {
		//Makes all GUI in this script look like the custom skin
		GUI.skin = custSkin;

		//Everything is put in this area
		GUILayout.BeginArea(new Rect(Screen.width/4,0,400,100));

		// Begin the Horizontal group
		GUILayout.BeginHorizontal();

		//Places a normal button
		if (GUILayout.RepeatButton("Increase max\nSlider Value")){
			maxSliderValue += 3.0f * Time.deltaTime;
		}

		//Arranges two or more controls vertically beside the button
		GUILayout.BeginVertical();
		GUILayout.Box("Slider Value: " + Mathf.Round(sliderValue));
		sliderValue = GUILayout.HorizontalSlider(sliderValue,0.0f,maxSliderValue);

		//End the groups and area
		GUILayout.EndVertical();
		GUILayout.EndHorizontal();
		GUILayout.EndArea();

	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
