using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FPLooker : MonoBehaviour {
	
	public enum lookWhere {XY, X, Y};
	public lookWhere lookOnly = lookWhere.XY;
	
	public enum Inertia {X, Y, Z, XY, NONE };
	public Inertia isUnderInertia = Inertia.NONE;
	
	public Vector2 turnSpeed;
	
	public float xSensitivity = 5.0f;
	public float ySensitivity = 5.0f;
	
	public float xMax = 360.0f;
	public float xMin = -360.0f;
	public float yMax = 70.0f;
	public float yMin = -70.0f;
	
	public float xRot = 0.0f;
	public float yRot = 0.0f;

	public float maxSpeed = 20.0f;

	private float xRotAverage, yRotAverage;
	public int frameCounterX = 35;
	public int frameCounterY = 35;

	private int stopCounter = 0;

	private List<float> rotArrayX = new List<float>();
	private List<float> rotArrayY = new List<float>();

	private float prevXRot, prevYRot;

	public float smoothFactor = 0.5f;
	
	Quaternion xQuat;
	Quaternion yQuat;
	Quaternion startRot;

	RaycastHit hit;
	// Use this for initialization
	void Start () {
		if(rigidbody)
		rigidbody.freezeRotation = true;
		startRot = transform.localRotation;
		Screen.showCursor = false;
	}
	
	// Update is called once per frame
	void Update () {


		if(lookOnly == lookWhere.XY){
			prevXRot = xRot;
			prevYRot = yRot;
			
			xRot += Input.GetAxis("Mouse X") * xSensitivity;
			yRot += Input.GetAxis("Mouse Y") * ySensitivity;
			
			turnSpeed.x = xRot-prevXRot;
			turnSpeed.y = yRot-prevYRot;
			
			/*if(turnSpeed.x != 0 && turnSpeed.y != 0)
				isUnderInertia = Inertia.XY;
			else if (turnSpeed.x != 0)
				isUnderInertia = Inertia.X;
			else if (turnSpeed.y != 0)
				isUnderInertia = Inertia.Y;
			else
				isUnderInertia = Inertia.NONE;*/

			
			xRot = inBoundsAngle(xRot, xMin, xMax);
			yRot = inBoundsAngle(yRot, yMin, yMax);
			
			//Inertia stuffs
			
			xRotAverage = 0.0f;
			yRotAverage = 0.0f; 
			
			rotArrayX.Add(xRot);
			
			if (rotArrayX.Count >= frameCounterX)
				rotArrayX.RemoveAt(0);
			
			for (int i = 0; i < rotArrayX.Count; i++)
				xRotAverage += rotArrayX[i];
			
			xRotAverage /= rotArrayX.Count;
			
			
			
			rotArrayY.Add(yRot);
			
			if (rotArrayY.Count >= frameCounterY)
				rotArrayY.RemoveAt(0);
			
			for (int i = 0; i < rotArrayY.Count; i++)
				yRotAverage += rotArrayY[i];
			
			yRotAverage /= rotArrayY.Count;
			
			
			xQuat = Quaternion.AngleAxis(xRotAverage, Vector3.up);
			yQuat = Quaternion.AngleAxis(yRotAverage, -Vector3.right);
			
			transform.localRotation = startRot * xQuat * yQuat;
		}
		else if(lookOnly == lookWhere.X){
			
			prevXRot = xRot;
			//prevYRot = yRot;


			xRot += Input.GetAxis("Mouse X") * xSensitivity;
			
			turnSpeed.x = xRot-prevXRot;
			//turnSpeed.y = 0.0f;
			
			if (turnSpeed.x != 0){
				isUnderInertia = Inertia.X;
				stopCounter = 0;
			}
			else if (++stopCounter == 60)
				isUnderInertia = Inertia.NONE;

			if(turnSpeed.x > maxSpeed)
				xRot = prevXRot + maxSpeed;
			else if(turnSpeed.x < -maxSpeed)
				xRot = prevXRot - maxSpeed;
			
			xRot = inBoundsAngle(xRot, xMin, xMax);
			//if(Mathf.Abs(transform.localRotation.x - xRot) > 90)
				//transform.localRotation = transform.localRotation * Quaternion.AngleAxis(transform.localRotation.x - xRot - 90, Vector3.up);

			if(isUnderInertia == Inertia.X){
				xQuat = Quaternion.AngleAxis(xRot, Vector3.up);
				transform.localRotation = Quaternion.RotateTowards(transform.localRotation, xQuat, (Quaternion.Angle(transform.localRotation, xQuat) * 3 * Time.smoothDeltaTime));
			}

		}
		else if(lookOnly == lookWhere.Y){
			
			//prevXRot = xRot;
			prevYRot = yRot;
			
			yRot += Input.GetAxis("Mouse Y") * ySensitivity;
			
			turnSpeed.y = yRot - prevYRot;
			//turnSpeed.x = 0.0f;
			
			if (turnSpeed.y != 0){
				isUnderInertia = Inertia.Y;
				stopCounter = 0;
			}
			else if (++stopCounter > 60 && Mathf.Sign(turnSpeed.y) == 1){
				//yRot /= (stopCounter/smoothFactor);
				isUnderInertia = Inertia.NONE;
			}
			else if (++stopCounter > 60 && Mathf.Sign(turnSpeed.y) == -1){
				//yRot /= (stopCounter/smoothFactor);
				isUnderInertia = Inertia.NONE;
			}

			if(turnSpeed.y > maxSpeed)
				yRot = prevYRot + maxSpeed;
			else if(turnSpeed.y < -maxSpeed)
				yRot = prevYRot - maxSpeed;
			
			yRot = inBoundsAngle(yRot, yMin, yMax);

			if(isUnderInertia == Inertia.Y){
				yQuat = Quaternion.AngleAxis(yRot, -Vector3.right);
				transform.localRotation = Quaternion.RotateTowards(transform.localRotation, yQuat, (Quaternion.Angle(transform.localRotation, yQuat) * 3 * Time.smoothDeltaTime));
			}
		}


	}
	
	float inBoundsAngle(float rot, float min, float max){
		
		if(rot < -360.0f)
			rot += 360.0f;
		else if(rot > 360.0f)
			rot -= 360.0f;
		
		rot = Mathf.Clamp(rot, min, max);
		
		return rot;
	}
}
