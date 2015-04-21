using UnityEngine;
using System.Collections;

public class PauseTrigger : MonoBehaviour {

	//MouseLook playerML;
	vp_FPInput playerML;
	vp_SimpleCrosshair crosshair;
	//MouseLook cameraML;
	public GameObject PauseGUI;
	public GameObject ControlGUI;

	Vector2 oldVec;
	Vector2 newVec;

	// Use this for initialization
	void Start () {
		/* Regular First Person Controller stuff */
		//playerML = GameObject.FindGameObjectWithTag("Player").GetComponent<MouseLook>();
		//cameraML = Camera.main.GetComponent<MouseLook>();

		/* For Hero character controller */
		playerML = GameObject.FindGameObjectWithTag("Player").GetComponent<vp_FPInput>();
		crosshair = GameObject.FindGameObjectWithTag("Player").GetComponent<vp_SimpleCrosshair>();
		oldVec = playerML.GetMouseLookSensitivity();
		PauseGUI.SetActive(false);
		crosshair.SetPaused(false);
		newVec = new Vector2(0.0f, 0.0f);
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.P))
		{
			if (Time.timeScale == 1)
			{
				Time.timeScale = 0;
				playerML.SetMouseLookSensitivity(newVec);
				crosshair.SetPaused(true);
				//playerML.enabled = false;
				//cameraML.enabled = false;
				playerML.MouseCursorForced = true;
				PauseGUI.SetActive(true);

			}
			else 
			{
				if(ControlGUI.activeSelf == false)
				{
					Time.timeScale = 1;
					playerML.SetMouseLookSensitivity(oldVec);
					playerML.MouseCursorForced = false;
					//crosshair.Paused = false;
					crosshair.SetPaused(false);
					//playerML.enabled = true;
					//cameraML.enabled = true;
					PauseGUI.SetActive(false);
				}
			}
		}

	
	}
}
