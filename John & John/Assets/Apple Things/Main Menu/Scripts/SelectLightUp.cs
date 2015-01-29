using UnityEngine;
using System.Collections;

public class SelectLightUp : MonoBehaviour {
	
	public GameObject optionScreen;
	public GameObject newGameScreen;
	public GameObject loadGameScreen;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (AnimationManager.animationIsPlaying()) gameObject.layer = 2; 
		else gameObject.layer = 0;

	}
	
	void OnMouseOver(){
		renderer.material.color = Color.cyan;
	}
	
	void OnMouseExit(){
		renderer.material.color = Color.white;
	}

	//A coroutine that makes the main camera wait until the current anim is finished before moving
	private IEnumerator selectFinish(int num){

		if (num==0) {
			gameObject.audio.Play ();
			AnimationManager.shadow[num].animation["SelectConfirmNewGameS"].speed = 1.0f;
			AnimationManager.shadow[num].animation["SelectConfirmNewGameS"].time = 0;
			AnimationManager.shadow[num].animation.Play();
			yield return new WaitForSeconds(AnimationManager.shadow[num].animation.clip.length);
			/*AnimationManager.mainCam.animation.Play("CameraToNewGame");
			AnimationManager.blurCam.animation.Play("CameraToNewGame");
			yield return new WaitForSeconds(AnimationManager.mainCam.animation.clip.length);*/
			if (gameObject.tag == "NewGame")AutoFade.LoadLevel("level01",2.0f,1.5f,Color.black);
			else if (gameObject.tag == "Quit") Application.Quit();
			//Application.LoadLevel("level01");
		}
		if (num==1){
			gameObject.audio.Play ();
			AnimationManager.shadow[num].animation["SelectConfirmLoadGameS"].speed = 1.0f;
			AnimationManager.shadow[num].animation["SelectConfirmLoadGameS"].time = 0;
			AnimationManager.shadow[num].animation.Play();
			yield return new WaitForSeconds(AnimationManager.shadow[num].animation.clip.length);
			/*AnimationManager.mainCam.animation.Play("CameraToLoadGame");
			AnimationManager.blurCam.animation.Play("CameraToLoadGame");
			yield return new WaitForSeconds(AnimationManager.mainCam.animation.clip.length);*/
			//loadGameScreen.SetActive(true);
			if (gameObject.tag == "Main")AutoFade.LoadLevel(0,2.0f,1.5f,Color.black);
			else AutoFade.LoadLevel(PlayerPrefs.GetInt("CurrentLevel"),2.0f,1.5f,Color.black);
		}
		if (num==2) {
			gameObject.audio.Play ();
			AnimationManager.shadow[num].animation["SelectConfirmOptionsS"].speed = 1.0f;
			AnimationManager.shadow[num].animation["SelectConfirmOptionsS"].time = 0;
			AnimationManager.shadow[num].animation.Play();
			yield return new WaitForSeconds(AnimationManager.shadow[num].animation.clip.length);
			AnimationManager.mainCam.animation["CameraToOptions"].time = 0;
			AnimationManager.mainCam.animation["CameraToOptions"].speed = 1.0f;
			AnimationManager.mainCam.animation.Play ("CameraToOptions");
			AnimationManager.blurCam.animation["CameraToOptions"].time = 0;
			AnimationManager.blurCam.animation["CameraToOptions"].speed = 1.0f;
			AnimationManager.blurCam.animation.Play ("CameraToOptions");
			yield return new WaitForSeconds(AnimationManager.mainCam.animation.clip.length);
			optionScreen.SetActive(true);
		}
	}
	
	void OnMouseDown(){
		if (gameObject.tag == "NewGame"){
			StartCoroutine(selectFinish(0));
			//Move to screen that lets you make a new game
		}
		else if (gameObject.tag == "LoadGame"){
			if (PlayerPrefs.GetInt("CurrentLevel") != null && PlayerPrefs.GetInt("CurrentLevel")!=0)
				StartCoroutine(selectFinish(1));
			//Move to load game screen
		}
		else if (gameObject.tag == "Options"){
			StartCoroutine(selectFinish(2));
			//Move to option screen
		}
		else if (gameObject.tag == "Quit"){
			StartCoroutine(selectFinish(0));
			//Move to option screen
		}
		else if (gameObject.tag == "Main"){
			StartCoroutine(selectFinish(1));
			//Move to option screen
		}
		
	}
	
	void OnBecameVisible(){
		if (AnimationManager.shadow!=null){
			AnimationManager.shadow[0].animation.Rewind();
			AnimationManager.shadow[1].animation.Rewind();
			AnimationManager.shadow[2].animation.Rewind();
		//	AnimationManager.shadow[3].animation.Rewind();
		//	AnimationManager.shadow[4].animation.Rewind();
		}
		else AnimationManager.shadow = GameObject.FindGameObjectsWithTag("ShadowText");
	}
}
