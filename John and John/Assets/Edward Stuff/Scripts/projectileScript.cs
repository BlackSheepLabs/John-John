using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// created by Markus Davey 22/11/2011
/// Basic projectile script
/// Skype: Markus.Davey
/// Unity forums: MarkusDavey
/// </summary>

public class projectileScript : MonoBehaviour 
{
	public Vector3 muzzleVelocity;
	
	public float TTL;
	
	public bool isBallistic;
	public float Drag; // in metres/s lost per second.
	
	public AudioSource deathSound;
	
	private GameObject[] PlayerList;
	public int canKill = 0;
	// Use this for initialization
	void Start () 
	{
		
		if (PlayerList == null){
			PlayerList = GameObject.FindGameObjectsWithTag("Player");
		}
		
		
		if (TTL == 0)
			TTL = 5;
		//print(TTL);
		Invoke("projectileTimeout", TTL);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Drag != 0)
			muzzleVelocity += muzzleVelocity * (-Drag * Time.deltaTime);
		
		if (isBallistic)
			muzzleVelocity += Physics.gravity * Time.deltaTime;
		
		if (muzzleVelocity == Vector3.zero)
			return;
		else {
			//rigidbody.velocity = muzzleVelocity;
			transform.position += muzzleVelocity * Time.deltaTime;
		}
		transform.LookAt(transform.position + muzzleVelocity.normalized);
		Debug.DrawLine(transform.position, transform.position + muzzleVelocity.normalized, Color.red);

		if(canKill > 0)
		{
			canKill -= 1;
			
		}

	}
	
	void projectileTimeout()
	{
		DestroyObject(gameObject);
	}
	
	void OnTriggerEnter(Collider C){
		if(canKill <= 0) {
			if(C.tag == "Player")
			{
				DestroyObject(gameObject);
				deathSound.enabled = true;
				deathSound.Play();
				
				Debug.Log("You Dead Son");
				C.gameObject.GetComponent<vp_FPPlayerDamageHandler>().Die();
				C.gameObject.GetComponent<vp_PlayerRespawner>().Die();
			}
			//Application.LoadLevel(Application.loadedLevel);
		} else {
			Debug.Log("YO");
			DestroyObject(gameObject);

		}
		
	}

}