using UnityEngine;
using System.Collections;

public class StartSequenceOnTrigger : MonoBehaviour {

	public GameObject AutoStartSequence;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider C)
	{
		if(AutoStartSequence != null)
			AutoStartSequence.SetActive(true);

	}
}
