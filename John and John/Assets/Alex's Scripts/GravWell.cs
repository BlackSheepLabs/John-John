using UnityEngine;
using System.Collections;

public class GravWell : MonoBehaviour {

//	public CapsuleCollider gravField;

	public Vector3 gravVector = Vector3.up;

	// Use this for initialization
	void Start () {
/*		if(gravField == null)
		{
			GameObject g = new GameObject();
			g.transform.parent = transform;
			gravField = g.AddComponent<CapsuleCollider>();
			g.transform.localPosition = Vector3.up;
			g.transform.localEulerAngles = Vector3.zero;
		}*/

//		gravField.isTrigger = true; 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other)
	{
		Debug.Log ("Object detected!");
		if(other == collider) return;
		Debug.Log ("Object detected!");
		Rigidbody r = other.attachedRigidbody;
		if(r != null)
		{
			Debug.Log ("Adding gravity!");
			Vector3 worldGravVector = gravVector.x * transform.right +
									  gravVector.y * transform.up +
									  gravVector.z * transform.forward;

			float radius = (other.transform.position - transform.position).sqrMagnitude/16.0f + 1;

			r.velocity += worldGravVector * Time.deltaTime / radius;
		}
	}
}
