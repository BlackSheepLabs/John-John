using UnityEngine;
using System.Collections;

public class SwitchTimer : MonoBehaviour {
	
	private Vector3 tempPosition;
	private Quaternion tempRotation;
	private Vector3 cloneEulerAngles; // added to avoid rotating the clone oddly
	public GameObject player;
	public GameObject clone;
	protected GameObject lastObj = null;

	public float SwitchTime;

	public GUISkin custSkin;

	AudioSource source;

	int countdown;

	float startTime;
	float curTime;
	float seconds;

	void Start()
	{
		startTime = Time.time;
		source = gameObject.GetComponent<AudioSource>();
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
		GUI.skin = custSkin;
		curTime = Time.time - startTime;

		seconds = (curTime % 60f);
		countdown = (int)((SwitchTime + 1) - seconds);

		//print to GUI
		if (countdown <= 0) {
			Swap ();
			startTime = Time.time;
		}
	
		GUI.TextArea(new Rect (Screen.width - 80f, Screen.height - 70f, 100f, 30f), countdown.ToString ());
	}

	private void Swap() {

		var moveObjs = FindObjectsOfType<vp_Grab>();
		GameObject heldObj = null;
		
		foreach(vp_Grab g in moveObjs)
		{
			if(g.IsGrabbed)
			{
				g.transform.rigidbody.isKinematic = true;
				g.transform.collider.enabled = false;
				g.TryInteract (null);
				heldObj = g.transform.gameObject;
				break;
			}
		}
		
		tempPosition = player.transform.position;
		player.transform.position = clone.transform.position;
		clone.transform.position = tempPosition;
		
		var cam = FindObjectOfType<vp_FPCamera>();
		
		var tempAngles = cloneEulerAngles;
		tempRotation = player.transform.rotation;
		cloneEulerAngles = cam.transform.eulerAngles;
		FindObjectOfType<vp_FPCamera>().SetRotation (tempAngles);
		//FindObjectOfType<vp_FPController>().
		clone.transform.rotation = tempRotation;
		
		if(lastObj != null)
		{
			lastObj.GetComponent<vp_Grab>().TryInteract(FindObjectOfType<vp_FPPlayerEventHandler>());
			lastObj.rigidbody.isKinematic = false;
			lastObj.collider.enabled = true;
		}
		
		lastObj = heldObj;
		
	
		source.Play();
	}
}
