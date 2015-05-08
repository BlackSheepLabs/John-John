using UnityEngine;
using System.Collections;

public class CharacterSwap : MonoBehaviour {
	// Delcare needed variables
	private Vector3 tempPosition;
	private Quaternion tempRotation;
	private Vector3 cloneEulerAngles; // added to avoid rotating the clone oddly
	public GameObject player;
	public GameObject clone;
	protected GameObject lastObj = null;

	void Awake() {
		QualitySettings.vSyncCount = 1;
		Camera.main.transparencySortMode = TransparencySortMode.Orthographic;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(1)) {
			Swap ();
		}
	}
	
	public void Swap() {

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

	}
}
