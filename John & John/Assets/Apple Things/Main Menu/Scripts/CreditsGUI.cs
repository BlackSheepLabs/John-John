using UnityEngine;
using System.Collections;

public class CreditsGUI : MonoBehaviour {

	Rect window;
	public GUISkin custSkin;
	
	// Use this for initialization
	void Start () {
		window = new Rect(Screen.width/3,Screen.height/16,
		                  /*Screen.width-(Screen.width/3 * 2)*/391,/*Screen.height-(Screen.height/8));*/494.375f);
		Debug.Log(Screen.width + " " + Screen.height + "\n");
	}
	
	// Update is called once per frame
	void OnGUI () {
			GUI.skin = custSkin;
			GUI.Box (window,"Credits");

		GUI.Label(new Rect(Screen.width/3,Screen.height/6,Screen.width/2,Screen.height/20), // 0
		          "From CMPS 427 and CMPS 490:");	
		GUI.Label(new Rect(Screen.width/3,Screen.height/6+30,Screen.width/2,Screen.height/20), // 30
		          "• Jason Woodworth   | jww7675");
		GUI.Label(new Rect(Screen.width/3,Screen.height/6+50,Screen.width/2,Screen.height/20), // 50
		          "• Rebecca Broussard | rab6597");
		GUI.Label(new Rect(Screen.width/3,Screen.height/6+70,Screen.width/2,Screen.height/20),  // 70
		          "• Edward Woods      | ebw3559");

		GUI.Label(new Rect(Screen.width/3,Screen.height/6 +110,Screen.width/2,Screen.height/20), // 110
		          "From CMPS 490:");	
		GUI.Label(new Rect(Screen.width/3,Screen.height/6+140,Screen.width,Screen.height/20), // 140
		          "• Marcus Shannon    | mns8949");
		GUI.Label(new Rect(Screen.width/3,Screen.height/6+160,Screen.width,Screen.height/5), // 160
		          "• Alex Richard      | adr6887");

		GUI.Label(new Rect(Screen.width/3,Screen.height/6+200,Screen.width/2,Screen.height/20),  //200
		          "From CMPS 427:");	
		GUI.Label(new Rect(Screen.width/3,Screen.height/6+230,Screen.width/2,Screen.height/20),  // 230
		          "• Alexander Breaux  | akb4152");
		GUI.Label(new Rect(Screen.width/3,Screen.height/6+250,Screen.width/2,Screen.height/20), // 250
		          "• Brandin Jefferson | bej0843");
		GUI.Label(new Rect(Screen.width/3,Screen.height/6+270,Screen.width,Screen.height/20),  // 270
		          "• Chau Cao          | cpc0639");
		GUI.Label(new Rect(Screen.width/3,Screen.height/6+290,Screen.width,Screen.height/20),  // 290
		          "• Robert Knott      | rjk6779");
	

		GUI.Label(new Rect(Screen.width/3,Screen.height/6+330,Screen.width,Screen.height/20),  // 330
		          "Music by Dylan Hebert (dph2340)");
		GUI.Label(new Rect(Screen.width/3,Screen.height/6+360,Screen.width,Screen.height/20),  // 370
		          "Original artwork done by Marcus Shannon");

			//Back button
		if (GUI.Button(new Rect(Screen.width/3+12,Screen.height/6+410,Screen.width/8,Screen.height/25),"Back")){
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
