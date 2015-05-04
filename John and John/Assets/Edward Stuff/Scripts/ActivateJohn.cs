using UnityEngine;
using System.Collections;

public class ActivateJohn : MonoBehaviour {

    public GameObject John;
    public GameObject JohnClone;
    public GameObject Camera;
	public GameObject PauseManager;
	public GameObject CharacterSwitch;

	// Use this for initialization
	void Start () {
        John.SetActive(true);
        JohnClone.SetActive(true);
        Camera.SetActive(false);
		PauseManager.SetActive (true);
		CharacterSwitch.SetActive (true);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
