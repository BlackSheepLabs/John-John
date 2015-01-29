using UnityEngine;
using System.Collections;

public class time : MonoBehaviour {

	private float generalTime;
	private float timerCap;
	
	private bool timerOn;
	private bool timerDone;
	// Use this for initialization
	void Start () {
		timerOn = false;
		Debug.Log("Timer Off");
		generalTime = 0.0f;
		timerCap = 1.0f;
		timerDone = false;
		StartTimer();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		runTimer();
		if(timerDone == true)
		{
			gameObject.particleSystem.Stop ();
			//Destroy(gameObject);
		}
		
	}
	
	void runTimer(){
		
		//If timer has been set to 'On', accumulate time in generalTime in seconds since timer 
		//started.
		if(timerOn){
			
			generalTime += Time.deltaTime;
			//Debug.Log("GeneralTime++");
			//If generalTime passes timerCap in value, stop the timer and set timerDone to
			//true.
			if (generalTime >= timerCap)
			{
				generalTime = 0.0f;
				timerOn = false;
				Debug.Log("Timer Done");
				timerDone = true;
				
			}
			
		}
		
		//else
		//Debug.Log("!GeneralTime++");
		
	}	
	
	
	
	//Function to start timer and set timerDone to false.
	public void StartTimer(){
		timerOn = true;
		timerDone = false;
		Debug.Log("Timer Started (Timer On)");
	}
	
	//Function to return current time accumulated by the timer.
	public float GetTime(){
		return generalTime;
	}
	
	//Function to test if the timer is running.
	public bool isTimerOn(){
		return timerOn;
	}
	
	//Function to test if the timer has recently finished.
	public bool isTimerDone(){
		return timerDone;	
	}
	
	public void setTimerCap(float cap){
		timerCap = cap;
	}
	
	//resets timer to default values and leaves timerCap intact for reuse
	public void resetTimer(){
		timerOn = false;
		timerDone = false;
		generalTime = 0.0f;
	}
}
