using UnityEngine;
using System.Collections;

public class ActivateJohn : MonoBehaviour {

    public GameObject John;
    public GameObject JohnClone;
    public GameObject Camera;

	// Use this for initialization
	void Start () {
        John.SetActive(true);
        JohnClone.SetActive(true);
        Camera.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
