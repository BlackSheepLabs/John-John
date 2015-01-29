using UnityEngine;
using System.Collections;

public class PauseControl : MonoBehaviour {

	static public bool isPaused;
	public GUISkin custSkin;

	Rect pauseBox2 = new Rect(Screen.width,Screen.height,Screen.width/4,Screen.height/3);
	Rect button1 = new Rect(225,100,Screen.width/6,Screen.height/25);
	Rect button2 = new Rect(225,170,Screen.width/6,Screen.height/25);
	Rect button3 = new Rect(225,240,Screen.width/6,Screen.height/25);
	Rect button4 = new Rect(225,310,Screen.width/6,Screen.height/25);
	//Rect button5 = new Rect(225,310,Screen.width/6,Screen.height/25);

	// Use this for initialization
	void Start () {
		isPaused = false;
		pauseBox2 = centerRectangle(pauseBox2);
		button1 = centerRectangle(button1);
		button2 = centerRectangle(button2);
		button3 = centerRectangle(button3);
		button4 = centerRectangle(button4);
		button1.y = pauseBox2.y + button1.height; //Resume
		button2.y = (button1.height*2) + button1.y; //Restart
		button4.y = (button2.height*2) + button2.y; //Options
		button3.y = (button4.height*2) + button4.y; //To main menu
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.P)){
			if (Time.timeScale == 1){
				Time.timeScale = 0;
				isPaused = true;
			}
			else {
				Time.timeScale = 1;
				isPaused = false;
			}
		}
	}

	//Return the centered rectangle
	Rect centerRectangle(Rect rec){
		rec.x = (Screen.width - rec.width)/2;
		rec.y = (Screen.height - rec.height)/2;
		return rec;
	}

	void OnGUI () {
		GUI.skin = custSkin;
		//Only run if the game is paused
		if(isPaused && !OptionMenuGUI.optionsOn && !ControlsGUI.controlsOn)
		{	
			
			GUI.Box(pauseBox2, "");
			
			//Draws and provides functionality to resume, restart, and quit buttons
			if(GUI.Button(button1, "Resume"))
			{
				Time.timeScale = 1;
				isPaused = false;
				ControlPauseBlur.script.enabled = false;	//BlurEffect
				ControlPauseBlur.script2.enabled = true;	//FPLooker Y
				ControlPauseLook.script.enabled = true;		//FPLooker X
				ControlPauseBlur.on = false;
				ControlPauseLook.on = false;
			}
			if(GUI.Button(button2, "Restart"))
			{
				Time.timeScale = 1;
				isPaused = false;
				Application.LoadLevel(Application.loadedLevelName);
			}

			if (GUI.Button(button4,"Options")){
				OptionMenuGUI.optionsOn = true;
			}
			if(GUI.Button(button3, "Quit"))
				Application.LoadLevel(0);		
			
			
		}
	}
}
