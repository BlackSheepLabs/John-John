using UnityEngine;
using System.Collections;

public class CubeOnMovingPlatform : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerStay(Collider t /* moving platform */)
    {
        Debug.Log("On trigger enter in " + gameObject.name);
        if (t.gameObject.tag == "Platform" && this.gameObject.tag == "MainCube")
        {
			Debug.Log("Parented");
            gameObject.transform.parent = t.gameObject.transform;
        }
    }

    void OnTriggerExit(Collider t)
    {
       // Debug.Log("On trigger exit in " + gameObject.name);
		if (t.gameObject.tag == "Platform" && this.gameObject.tag == "MainCube")
        {
            gameObject.transform.parent = null;
        //    Debug.Log("Unparented");
        }
    }
}
