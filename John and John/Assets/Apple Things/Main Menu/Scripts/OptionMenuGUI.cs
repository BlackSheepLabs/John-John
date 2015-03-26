using UnityEngine;
using System.Collections;

public class OptionMenuGUI : MonoBehaviour {

	public GUISkin custSkin;
	private string title;
	private Rect window;
	//Volume Variables
	/*private static float sfxVol = 1.0f;
	private static float musicVol = 1.0f;*/
	private static float curVol = 1.0f;
	private static bool subToggle = true;
	public static bool optionsOn;

	// Use this for initialization
	void Start () {
		window = new Rect(Screen.width/8,Screen.height/16,
		                  Screen.width-(Screen.width/8 * 2),Screen.height-(Screen.height/16 * 2));
		curVol = PlayerPrefs.GetFloat("AudioVolume");
		int subtog = PlayerPrefs.GetInt("Subtitle");
		if (subtog == 0) subToggle = false;
		else subToggle = true;
		optionsOn = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {


		if ((Application.loadedLevel == 0 && !optionsOn) || (Application.loadedLevel != 0 && optionsOn)){
			GUI.skin = custSkin;
			//window = GUI.Window(0,window,WindowFunct,"Options");
			GUI.Box(window,"Options");
			
			//Volume Control
			//On every scene, put a script that will make AudioListener equal curVol
			GUI.Label(new Rect(Screen.width/7,Screen.height/6-5,Screen.width/4,Screen.height/20),"Volume");
			curVol = GUI.HorizontalSlider(new Rect(Screen.width/2,Screen.height/6,Screen.width/3,Screen.height/40),curVol,0.0f,1.0f);
			AudioListener.volume = curVol;
			float vol = Mathf.CeilToInt(curVol*100f); //Round this to nearest tens place
			GUI.Label(new Rect(Screen.width/2.2f,Screen.height/6-5,Screen.width/3,Screen.height/20),vol.ToString());
			PlayerPrefs.SetFloat("AudioVolume",curVol);
			
			
			//Subtitle Control
			GUI.Label(new Rect(Screen.width/7,Screen.height/4,Screen.width/4,Screen.height/20),"Subtitles");
			string toggled = "Off";
			if (subToggle) toggled = "On";
			subToggle = GUI.Toggle(new Rect(Screen.width/2,Screen.height/4,Screen.width/3,Screen.height/20),subToggle,toggled);
			if (subToggle) PlayerPrefs.SetInt("Subtitle",1);
			else PlayerPrefs.SetInt("Subtitle",0);
			

			//Moving to Controls view
			if (GUI.Button(new Rect(Screen.width/7,Screen.height/3,Screen.width/6,Screen.height/25),"Controls")){
				ControlsGUI.controlsOn = true;
				//optionsOn = false;
				optionsOn = !optionsOn;
			}
			
			//Back Button
			if (Application.loadedLevel == 0){
				if (GUI.Button(new Rect(Screen.width/7,Screen.height/1.15f,Screen.width/6,Screen.height/25),"Back")){
					AnimationManager.mainCam.animation["CameraToOptions"].speed = -1.0f;
					AnimationManager.mainCam.animation["CameraToOptions"].time = AnimationManager.mainCam.animation["CameraToOptions"].length;
					AnimationManager.blurCam.animation["CameraToOptions"].speed = -1.0f;
					AnimationManager.blurCam.animation["CameraToOptions"].time = AnimationManager.blurCam.animation["CameraToOptions"].length;
					AnimationManager.shadow[2].animation["SelectConfirmOptionsS"].speed = -1.0f;
					AnimationManager.shadow[2].animation["SelectConfirmOptionsS"].time = AnimationManager.shadow[2].animation["SelectConfirmOptionsS"].length;
					AnimationManager.shadow[2].animation.Play("SelectConfirmOptionsS");
					optionsOn = false;
					StartCoroutine(backFinish());
				}
			}
			else {
				if (GUI.Button(new Rect(Screen.width/7,Screen.height/1.15f,Screen.width/6,Screen.height/25),"Back")){
					//optionsOn = false;
					optionsOn = !optionsOn;
				}
			}
		}
	}

	private IEnumerator backFinish(){
		gameObject.SetActive(false);
		AnimationManager.mainCam.animation.Play ("CameraToOptions");
		AnimationManager.blurCam.animation.Play ("CameraToOptions");
		yield return new WaitForSeconds(AnimationManager.mainCam.animation.clip.length);
	}

	//This doesn't look like it'll work correctly.
	void WindowFunct(int windowID){
		switch (windowID){
		case 0:
			title = "Volume";
			break;
		default:
			title = "Error";
			break;
		}
		if (GUI.Button(new Rect(5,30,50,100),title)){
			GUI.Label(new Rect(200,40,150,100),"Volume's Here.");
			Debug.Log("Works");
		}
	}
}
