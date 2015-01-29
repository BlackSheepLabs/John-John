using UnityEngine;
using System.Collections;

public class PracticeMenuState : MonoBehaviour {

	public Texture2D button;
	public GameObject cube;
	public GameObject sphere;
	bool sphereOn = false;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		if (GUI.Button(new Rect(10,70,100,20),"To Red")) {
			cube.renderer.material.color = Color.red;
			audio.Play ();
		}
		if (GUI.Button(new Rect(10,90,100,20),new GUIContent("To Blue","Isn't this self explanatory?"))) {
			cube.renderer.material.color = Color.blue;
		}
		if (GUI.Button(new Rect(10,110,100,20),"Make a circle.")) {
			if (!sphereOn){
				sphere.SetActive(true);		
				//Replaces destroy and instantiate problems.
				//This makes hiding objects a lot easier by deactivating them.
				//Can start them deactivated through code or the checkbox next to their names in
				//the builder.
				sphereOn = true;
			}
			else {
				sphere.SetActive(false);
				sphereOn = false;
			}
		}

		//The following is an example of a tooltip. By placing the mouse over a button or something
		//a message will appear.
		GUI.Button (new Rect(10,10,100,50),new GUIContent("Hover Over This","And a tooltip appears."));
		GUI.Label (new Rect(150,10,100,40),GUI.tooltip);



	}
}
