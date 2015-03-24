using UnityEngine;
using System.Collections;

public class TeleportMaster : MonoBehaviour {

	public static int totalJohns = 0;

	void Update(){
		if (TeleportMaster.totalJohns == 2){
			Application.LoadLevel(Application.loadedLevel+1);
		}
	}
}
