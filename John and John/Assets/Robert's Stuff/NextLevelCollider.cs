using UnityEngine;
using System.Collections;

public class NextLevelCollider : MonoBehaviour {

	int delay = 2;
	int transDelay;

	// Use this for initialization
	void Start ()
	{
		int loadLev = Application.loadedLevel;
		Debug.Log ("loadedLevel: "+ loadLev);
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	void OnTriggerEnter(Collider col)
	{
		//col.gameObject.name is the player controlled object
		//When col.gameObject.name collides, it moves on to the next level
		if(col.gameObject.name == "Sphere" || col.gameObject.name == "First Person Controller")
		{
			if(Application.loadedLevel + 1 < Application.levelCount)
			{
				Application.LoadLevel(Application.loadedLevel + 1);
			}
		}
		}

}
