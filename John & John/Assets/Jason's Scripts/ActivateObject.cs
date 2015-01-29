using UnityEngine;
using System.Collections;

public class ActivateObject : MonoBehaviour {
	
	public Material activateMaterial, deactivateMaterial;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void ObjectActivate() {
		gameObject.renderer.material = activateMaterial;
	}
	
	void ObjectDeactivate() {
		gameObject.renderer.material = deactivateMaterial;
	}
}
