using UnityEngine;
using System.Collections;

public class PauseTrigger : MonoBehaviour {

	MouseLook playerML;
	MouseLook cameraML;
	public GameObject PauseGUI;
	public GameObject ControlGUI;

	// Use this for initialization
	void Start () {

		playerML = GameObject.FindGameObjectWithTag("Player").GetComponent<MouseLook>();
		cameraML = Camera.main.GetComponent<MouseLook>();
		PauseGUI.SetActive(false);
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.P))
		{
			if (Time.timeScale == 1)
			{
				Time.timeScale = 0;
				playerML.enabled = false;
				cameraML.enabled = false;
				PauseGUI.SetActive(true);

			}
			else 
			{
				if(ControlGUI.activeSelf == false)
				{
					Time.timeScale = 1;
					playerML.enabled = true;
					cameraML.enabled = true;
					PauseGUI.SetActive(false);
				}
			}
		}

	
	}
}
