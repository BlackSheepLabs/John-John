using UnityEngine;
using System.Collections;

public class DualSwitches : MonoBehaviour
{
		enum SwitchState
		{
				ON,
				OFF}
		;

		enum ActivateState
		{
				ON,
				OFF}
		;

		private ActivateState activateState;
		public GameObject[] activatedObjects;
		public GameObject[] activatedSwitches;
		public Material onMaterial;
		public Material offMaterial;
		private SwitchState switchState;
		public bool swapped;
		private float swappedTimer;
		public bool Stay;

		void Start ()
		{

				activateState = ActivateState.OFF;
				switchState = SwitchState.OFF;
				swapped = false;
				swappedTimer = .05f;
		}

		void Update ()
		{
				if (onMaterial != null && offMaterial != null) {
						if (switchState == SwitchState.ON) {
								gameObject.renderer.material = onMaterial;
						} else if (switchState == SwitchState.OFF) {
								gameObject.renderer.material = offMaterial;
						}
				}
		
				if (swapped) {
						swappedTimer -= Time.deltaTime;
				}
				if (swappedTimer <= 0) {
						swapped = false;
						swappedTimer = .05f;
				}
		
				if (Input.GetMouseButtonDown (1)) {
						swapped = true;
				}
		
				//Debug.Log(swapped);
		}

		void OnTriggerEnter (Collider other)
		{
				if (other.tag == "Player") {
						foreach (GameObject obj in activatedSwitches) {
								obj.SendMessage ("ObjectActivate", SendMessageOptions.DontRequireReceiver);
						}
						switchState = SwitchState.ON;
				}
				if (other.tag == "Clone") {
						foreach (GameObject obj in activatedSwitches) {
								obj.SendMessage ("ObjectActivate", SendMessageOptions.DontRequireReceiver);
						}
						switchState = SwitchState.ON;
				}

				foreach (GameObject obj in activatedSwitches) {
						SwitchState s1State = switchState;
						SwitchState s2State = obj.GetComponent<DualSwitches> ().switchState;
						ActivateState a1State = activateState;
						ActivateState a2State = obj.GetComponent<DualSwitches> ().activateState;

						if (s1State == SwitchState.ON && s2State == SwitchState.ON &&
								a1State == ActivateState.ON && a2State == ActivateState.ON) {
								foreach (GameObject obj2 in activatedObjects) {
										obj2.SendMessage ("ObjectActivate", SendMessageOptions.DontRequireReceiver);
								}
						}
				}

		}
	
		void OnTriggerExit (Collider other)
		{
				if (other.tag == "Player") {
						if (swapped == false) {
								switchState = SwitchState.OFF;
								foreach (GameObject obj in activatedObjects) {
										if (!Stay)
												obj.SendMessage ("ObjectDeactivate", SendMessageOptions.DontRequireReceiver);

								}
								foreach (GameObject obj in activatedSwitches) {
										obj.SendMessage ("ObjectDeactivate", SendMessageOptions.DontRequireReceiver);
								}
						}
				}

		}

		void ObjectActivate ()
		{
				activateState = ActivateState.ON;

		}
	
		void ObjectDeactivate ()
		{
				activateState = ActivateState.OFF;
		}

}
