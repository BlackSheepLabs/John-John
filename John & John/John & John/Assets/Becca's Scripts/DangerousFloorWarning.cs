using UnityEngine;
using System.Collections;

public class DangerousFloorWarning : MonoBehaviour {

	public static float levelReload;
	public static int levelTime;

	// Use this for initialization
	void Start () {
	

		levelReload = 5f;
		levelTime = 0;

	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void OnGUI()
	{


				levelReload -= Time.deltaTime;
				levelTime = (int)levelReload;
				string stringReset = "This section of the floor is too dangerous to walk on.\nGet off this floor before it's too late!\nRestarting level in " + levelTime + " seconds.";
				stringReset = GUI.TextArea (new Rect (Screen.width / 2, Screen.height / 2, 200, 200), stringReset, 200);

				if (levelTime == 0) {
					Application.LoadLevel (Application.loadedLevel);
				}

	}


}
