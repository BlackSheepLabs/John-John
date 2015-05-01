using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour {

	public GameObject OptionsManager;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevel == 0){
			
			AnimationManager.mainCam.animation["CameraToOptions"].speed = -1.0f;
			AnimationManager.mainCam.animation["CameraToOptions"].time = AnimationManager.mainCam.animation["CameraToOptions"].length;
			AnimationManager.blurCam.animation["CameraToOptions"].speed = -1.0f;
			AnimationManager.blurCam.animation["CameraToOptions"].time = AnimationManager.blurCam.animation["CameraToOptions"].length;
			AnimationManager.shadow[2].animation["SelectConfirmOptionsS"].speed = -1.0f;
			AnimationManager.shadow[2].animation["SelectConfirmOptionsS"].time = AnimationManager.shadow[2].animation["SelectConfirmOptionsS"].length;
			AnimationManager.shadow[2].animation.Play("SelectConfirmOptionsS");
			//optionsOn = false;
			StartCoroutine(backFinish());
			OptionsManager.SetActive(false);
			//this.gameObject.SetActive(false);
			this.enabled = false;
			
		}
		
	}
	
	private IEnumerator backFinish(){
		//gameObject.SetActive(false);
		AnimationManager.mainCam.animation.Play ("CameraToOptions");
		AnimationManager.blurCam.animation.Play ("CameraToOptions");
		yield return new WaitForSeconds(AnimationManager.mainCam.animation.clip.length);
	}
	
}
