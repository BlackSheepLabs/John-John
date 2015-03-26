using UnityEngine;
using System.Collections;

//save applied to button
public class Save : MonoBehaviour {


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
		if(GUI.Button(new Rect(0, 0, 50, 50), "Save"))
		{
			level = Application.loadedLevel;
			Debug.Log (level);
			PlayerPrefs.SetInt ("CurrentLevel", level);
			Debug.Log(PlayerPrefs.GetInt("CurrentLevel"));
		}
	}
}
