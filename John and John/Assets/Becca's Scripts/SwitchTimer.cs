using UnityEngine;
using System.Collections;

public class SwitchTimer : MonoBehaviour {

	public float SwitchTime;
	public GUISkin customSkin;

	float timeElapse;
	int curTime;

	float blah;
	float meh;
	float seconds;
	void Start()
	{
		//StartCoroutine("MyEvent");
		GUI.skin = customSkin;
		//SwitchTime = curTime;
		blah = Time.time;
	}

	void Update()
	{

	}

	void OnGUI()
	{
		meh = Time.time - blah;

		seconds = (meh % 60f);
		curTime = (int)(SwitchTime - seconds);
		//timeElapse -= Time.deltaTime;
		//curTime = (int)timeElapse;
		//print to GUI
		GUI.Label(new Rect(400f, 25f, 100f, 30f), curTime.ToString());
		
	}
}
