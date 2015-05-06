using UnityEngine;
using System.Collections;

//save applied to button
public class Save : MonoBehaviour {

	public GUISkin customSkin;
	//this variable is for my own purposes and not 
	//necessary for script to function
	public static int levelNumber;

	private int level;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI()
	{
		GUI.skin = customSkin;
		//if(GUI.Buttonl(new Rect(0, 0, 50, 50), "Save"))
		//{
		level = Application.loadedLevel;
		Debug.Log (level);
		PlayerPrefs.SetInt ("CurrentLevel", level);
		Debug.Log(PlayerPrefs.GetInt("CurrentLevel"));
		if(PlayerPrefs.GetInt("CurrentLevel") == level)
		{
			GUI.Label(new Rect((Screen.width - 125)/35, (Screen.height - 90f), 125, 75), "Saved");
		}

		//}
	}
}
