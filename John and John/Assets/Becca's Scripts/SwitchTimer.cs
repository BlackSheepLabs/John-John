using UnityEngine;
using System.Collections;

public class SwitchTimer : MonoBehaviour {
	
	// Declare needed variables
	private Vector3 tempPosition;
	private Quaternion tempRotation;
	private Vector3 cloneEulerAngles; // added to avoid rotating the clone oddly
	public GameObject player;
	public GameObject clone;

	public float SwitchTime;

	public Font font;
	public Texture logoTexture;

	float timeElapse;
	int curTime;

	float blah;
	float meh;
	float seconds;

	void Start()
	{
		blah = Time.time;
		GUI.skin.label.font = font;
		GUI.skin.label.fontSize = 30;
	}

	void Awake() {
		QualitySettings.vSyncCount = 1;
		Camera.main.transparencySortMode = TransparencySortMode.Orthographic;
	}

	void Update()
	{

	}

	void OnGUI()
	{
		meh = Time.time - blah;

		seconds = (meh % 60f);
		curTime = (int)((SwitchTime + 1) - seconds);

		//print to GUI
		if (curTime == 0) {
			Swap ();
			blah = Time.time;
		}

		//GUI.DrawTexture (new Rect(Screen.width - 40f, Screen.height - 50f, 100f, 30f), logoTexture);
		GUI.Label (new Rect (Screen.width - 45f, Screen.height - 50f, 100f, 30f), curTime.ToString ());
	}

	private void Swap() {
		
		tempPosition = player.transform.position;
		player.transform.position = clone.transform.position;
		clone.transform.position = tempPosition;
		
		var cam = FindObjectOfType<vp_FPCamera>();
		
		var tempAngles = cloneEulerAngles;
		tempRotation = player.transform.rotation;
		cloneEulerAngles = cam.transform.eulerAngles;
		FindObjectOfType<vp_FPCamera>().SetRotation (tempAngles);
		clone.transform.rotation = tempRotation;
	}
}
