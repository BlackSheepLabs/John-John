using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	
	
	//Declare GameObject for character and the floor	
	public GameObject floor;
	
	//Declare variables for cube movement options
	float moveSpeed = 0.05f;
	float jumpSpeedCap = 0.5f;
	float jumpSpeed = 0.0f;
	
	bool isJumping, isRunning, isFalling, isMoving;
	//Declare State System for states of moving object
	public StateSystem testSystem;
	
	// Use this for initialization
	void Start () {
		
		testSystem = new StateSystem();
		//Initialize all states to "false"
		isJumping = false;
		isMoving = false;
		isFalling = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		
			
		getInput ();
		
		//Debug log output
		if((isJumping || isFalling) && isMoving)
			Debug.Log ("Player is running in midair (WHAAAATTTT?!?!?!)");
		else if(isMoving)
			Debug.Log ("Player is running");
		else if(isJumping)
			Debug.Log ("Player is jumping");
		else if(isFalling)
			Debug.Log ("Player is falling");
		else
			Debug.Log ("Player is being lazy");
		
		
		jumpstuff();
	
	}
	
	void getInput()
	{
		//Move right if D is pressed at predetermined speed, cubeSpeed
		if(Input.GetKey(KeyCode.D)){
			transform.position += transform.TransformDirection(Vector3.right) * moveSpeed;
			isMoving = true;
		}
		
		//Move left if A is pressed at predetermined speed, cubeSpeed
		else if(Input.GetKey(KeyCode.A)){
			transform.position -= transform.TransformDirection(Vector3.right) * moveSpeed;
			isMoving = true;
		}
		
		//Move back if W is pressed at predetermined speed, cubeSpeed
		else if(Input.GetKey(KeyCode.W)){

			transform.position += transform.TransformDirection(Vector3.forward) * moveSpeed;
			isMoving = true;
		}
		
		//Move forward if S is pressed at predetermined speed, cubeSpeed
		else if(Input.GetKey(KeyCode.S)){
			transform.position -= transform.TransformDirection(Vector3.forward) * moveSpeed;
			isMoving = true;
		}
		
		//If no keys are pressed, cube is not moving
		else isMoving = false;
		
		
		//If Space is pressed, jump; If already jumping or falling calculate position relative to gravity
		if(Input.GetKeyDown(KeyCode.Space))
		{
			isJumping = true;
			//cube.transform.position += new Vector3(0,jumpSpeed,0);
			/*
			 * jumpSpeed -= grav;
			
			//If cube's upwards velocity is negative, cube is falling
			if (cubeJump < 0)
			{
				isFalling = true;
				isJumping = false;
			}
	
			//If the cube is touching the floor and it is falling, the cube is no longer in the air
			if(floor.transform.position.y >= cube.transform.position.y-0.5f && isFalling == true)
			{
				isJumping = false;
				isFalling = false;
				cubeJump = 0.1f;
				cube.transform.position = new Vector3(cube.transform.position.x,0.5f,cube.transform.position.z);
			}
			*/
		}
		
		
	}
	
	void jumpstuff()
	{
		if(isJumping == true && jumpSpeed < jumpSpeedCap)
		{
			jumpSpeed += 0.01f;
			transform.position += new Vector3(0,jumpSpeed,0);
		}
		else
		{
			isJumping = false;
			jumpSpeed = 0.0f;
		}
	}
}