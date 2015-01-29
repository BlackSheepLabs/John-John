using UnityEngine;
using System.Collections;

public class BoxExplode : MonoBehaviour {
	
	/*Attach this script to each obstacle in the level.
	 * After the script is attached in the inspector of
	 * the obstacle, under Box Explode Script, Fragment 
	 * must be have fragmentation game object selected.
	 * Box must have the obstacle's game object selected.
	 * Ship must have the player character selected.
	 */

	public bool collisionState = false;
	public Rigidbody fragment;		
	public GameObject box;			
	public GameObject ship;			
	public GameObject gib;
	
	//public ParticleSystem myPartSys;
	
	public Rigidbody clone1;
	// Update is called once per frame
	void Update ()
	{
		BoxExplosionLoop();
		
		
		
	}
	
	

	void OnTriggerEnter(Collider ship)
	{
		Debug.Log ("Collision!");
		
		if(ship.tag == "Player") //If the player hit the obstacle
		{
			collisionState = true;
		}
		
		else
			collisionState = false;
		
		
	}
	
	
	void OnTriggerExit()
	{
		Debug.Log ("Obstacle Destroyed");
		collisionState = false;
		
		
	}
	

	void BoxExplosionLoop()
	{
		
		if(collisionState)
		{
			
			for (int i=0; i<80;i++)
				Instantiate(gib, transform.position, Random.rotation);
			Destroy(box);	
				

		}
		 
	}
	
}	

