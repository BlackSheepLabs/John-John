using UnityEngine;
using System.Collections;

public class CreditsGUI : MonoBehaviour {

	Rect window;
	public GUISkin custSkin;
	
	// Use this for initialization
	void Start () {
		window = new Rect(Screen.width/8,Screen.height/16,
		                  Screen.width-(Screen.width/6 * 2),Screen.height-(Screen.height/8 * 2));
	}
	
	// Update is called once per frame
	void OnGUI () {
			GUI.skin = custSkin;
			GUI.Box (window,"Credits");
			
		GUI.Label(new Rect(Screen.width/6,Screen.height/6,Screen.width/2,Screen.height/20),
		          "Alexander Breaux | akb4152");
		GUI.Label(new Rect(Screen.width/6,Screen.height/6+40,Screen.width/2,Screen.height/20),
		          "Brandin Jefferson | bej0843");
		GUI.Label(new Rect(Screen.width/6,Screen.height/6+80,Screen.width/2,Screen.height/20),
		          "Rebecca Broussard | rab6597");
		GUI.Label(new Rect(Screen.width/6,Screen.height/6+120,Screen.width/2,Screen.height/20),
		          "Jason Woodworth | jww7675");
		GUI.Label(new Rect(Screen.width/6,Screen.height/6+160,Screen.width/2,Screen.height/20),
		          "Edward Woods | ebw3559");
		GUI.Label(new Rect(Screen.width/6,Screen.height/6+200,Screen.width,Screen.height/20),
		          "Chau Cao | cpc0639");
		GUI.Label(new Rect(Screen.width/6,Screen.height/6+240,Screen.width,Screen.height/20),
		          "Robert Knott | rjk6779");
		GUI.Label(new Rect(Screen.width/6,Screen.height/6+280,Screen.width,Screen.height/20),
		          "Dylan Hebert | dph2340");
			
			//Back button
			if (GUI.Button(new Rect(Screen.width/7,Screen.height/1.35f,Screen.width/6,Screen.height/25),"Back")){
				AnimationManager.mainCam.animation["CameraToOptions"].speed = -1.0f;
				AnimationManager.mainCam.animation["CameraToOptions"].time = AnimationManager.mainCam.animation["CameraToOptions"].length;
				AnimationManager.blurCam.animation["CameraToOptions"].speed = -1.0f;
				AnimationManager.blurCam.animation["CameraToOptions"].time = AnimationManager.blurCam.animation["CameraToOptions"].length;
				AnimationManager.shadow[2].animation["SelectConfirmOptionsS"].speed = -1.0f;
				AnimationManager.shadow[2].animation["SelectConfirmOptionsS"].time = AnimationManager.shadow[2].animation["SelectConfirmOptionsS"].length;
				AnimationManager.shadow[2].animation.Play("SelectConfirmOptionsS");
				StartCoroutine(backFinish());
			}
	}

	private IEnumerator backFinish(){
		gameObject.SetActive(false);
		AnimationManager.mainCam.animation.Play ("CameraToOptions");
		AnimationManager.blurCam.animation.Play ("CameraToOptions");
		yield return new WaitForSeconds(AnimationManager.mainCam.animation.clip.length);
	}
}
