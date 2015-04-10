using UnityEngine;
using System.Collections;

public class FixChildPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Vector3 v = new Vector3();
		v.z = 2;
		transform.localPosition = v;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
