using UnityEngine;
using System.Collections;

public class RisingStairs : MonoBehaviour {
	enum ActivateState {ON, OFF}
	private ActivateState activateState;

	float timeLeft = 4.35f;

	GeneralTimer AnimTimer;

	private Animator anim;
	// Use this for initialization
	void Start () {
		//animation.Stop();
		activateState = ActivateState.OFF;
		//animation.wrapMode = WrapMode.Once;
		//GetComponent<Animator>().SetBool("Rise",true);
		anim =  GetComponent<Animator>();
	}


	// Update is called once per frame
	void Update () {
		//if(GetComponent<Animator>().GetBool("Rise"))
			//Debug.Log("laksjdhfoie\n");
		//currentState = anim.GetCurrentAnimatorStateInfo(0);

	    if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.StairsRising") && timeLeft > 0)
		{
			GetComponent<AudioSource>().Play();
			timeLeft -= Time.deltaTime;
		}

		if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Stairs Falling") && timeLeft > -2)
		{
			GetComponent<AudioSource>().Play();
			timeLeft -= Time.deltaTime;
		}

	}

	void ObjectActivate() {
		activateState = ActivateState.ON;
		GetComponent<Animator>().SetBool("Rise",true);
	}

	void ObjectDeactivate() {
		activateState = ActivateState.OFF;
		GetComponent<Animator>().SetBool("Rise",false);
	}
}

