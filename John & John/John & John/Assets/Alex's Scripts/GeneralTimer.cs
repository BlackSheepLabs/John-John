using UnityEngine;
using System.Collections;


//This is a script for a timer that can be used for general purposes in the background.
//For example: waiting for a particular charge time on some given state change.
public class GeneralTimer : MonoBehaviour {
	
	private float generalTime;
	private float timerCap;
	
	private bool timerOn;
	private bool timerDone;
	// Use this for initialization
	void Start () {
		timerOn = false;
		Debug.Log("Timer Off");
		generalTime = 0.0f;
		timerCap = 5.0f;
		timerDone = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		runTimer();
		
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
