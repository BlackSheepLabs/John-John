using UnityEngine;
using System.Collections;

public class PoisonFog : MonoBehaviour {

	public AudioSource deathSound;
	public int canKill = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(canKill > 0)
		{
			canKill -= 1;

		}
	}

	void OnTriggerEnter(Collider C)
	{
		if(canKill <= 0) {//C.gameObject.GetComponent<vp_PlayerRespawner>().LastRespawnTime < Time.time + 0.5f){
			if(C.tag == "Player")
			{
				//deathSound.enabled = true;
				//deathSound.Play();

				//foreach(BoxCollider c in this.GetComponentsInChildren<BoxCollider>())
				//	c.enabled = false;

				Debug.Log("You Dead Son");
				C.gameObject.GetComponent<vp_FPPlayerDamageHandler>().Die();
				C.gameObject.GetComponent<vp_PlayerRespawner>().Die();
			}
		}

		if(C.tag == "MainCube")
		{
			PowerCube p = C.gameObject.GetComponent<PowerCube>();
			p.Reset();
		}
	}

}
