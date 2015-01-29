using UnityEngine;
using System.Collections;

public class CharacterSwap : MonoBehaviour {
	// Delcare needed variables
	private Vector3 tempPosition;
	private Quaternion tempRotation;
	public GameObject player;
	public GameObject clone;

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
	
	private void Swap() {
		
		tempPosition = player.transform.position;
		player.transform.position = clone.transform.position;
		clone.transform.position = tempPosition;
		
		
		tempRotation = player.transform.rotation;
		player.transform.rotation = clone.transform.rotation;
		clone.transform.rotation = tempRotation;
		
	}
}
