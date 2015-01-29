using UnityEngine;
using System.Collections;

public class LoadNextLevel : MonoBehaviour {


	void Update() {
		if(Input.GetKeyDown(KeyCode.F12))
		   AutoFade.LoadLevel(Application.loadedLevel +1, 1, 1, Color.black);
		if (Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();
	}
	void ObjectActivate() {
		AutoFade.LoadLevel(Application.loadedLevel +1, 1, 1, Color.black);
	}
}
