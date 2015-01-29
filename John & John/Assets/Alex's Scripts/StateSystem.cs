using UnityEngine;
using System.Collections;
//This class creates a ScriptableObject that encapsulates a general state system for basic states. 
//Use this StateSystem class to create the base of your state system instead of declaring so many boolean 
//values at the start of your code. 

//public class StateSystem : MonoBehaviour {
public class StateSystem : ScriptableObject {
	
	
	public bool isMoving = false;
	public bool isJumping = false;
	public bool isFalling = false;
	public bool isColliding = false;
	//public bool* extraStateArray;


	//Start sets default values to your states and some variables inherited from
	//ScriptableObject.
	void Start () {
		//Name literally gives a ScriptableObject a global name by which it can be
		//identified. (Leave this alone).
		name = "StateSystem";

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	/*
	//This function can dynamically allocate an array of extra states based on your needs.
	void createExtraStateArray(int numStates, bool initVal){
		
		extraStateArray = new bool[numStates];
		for(int i = 0; i < numStates; i++)
			createExtraStateArray[i] = initVal;
	}
	*/
		
	

	
}






