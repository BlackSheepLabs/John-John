using UnityEngine;
using System.Collections;

public class TeleportToNextLevel : MonoBehaviour {


	void OnTriggerEnter(){
			TeleportMaster.totalJohns++;
			Debug.Log(TeleportMaster.totalJohns);
	}

	void OnTriggerExit(){
			TeleportMaster.totalJohns--;
			Debug.Log(TeleportMaster.totalJohns);
	}
}
