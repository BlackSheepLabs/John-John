using UnityEngine;
using System.Collections;

public class pathTraverser : MonoBehaviour {

	public enum TrackingMode
	{
		FixedDirection,
		RollerCoaster,
		Observe,
		Track,
		None
	};

	public TrackingMode mode = TrackingMode.FixedDirection;

	public Vector3 directionToLook;
	public GameObject objectToFollow;


	public AnimationCurve speed;
	public BezierPath pathToFollow;
	public float t = 0;
	Vector3 lastPoint = Vector3.zero;
	// Use this for initialization
	void Start () {
		lastPoint = pathToFollow.GetPoint(t);
	}
	
	// Update is called once per frame
	void Update () {
		if(t < 1.0f)
		{
			bool finished = false;
			float dSpeed = Mathf.Abs(speed.Evaluate(t));
			float dist = 0.0f;
			while(t < 1.0f && !finished)
			{
				Vector3 prev = transform.position;
				t += dSpeed/(pathToFollow.GetLength(t)*20)*Time.deltaTime;
				dist += (pathToFollow.GetPoint (t)-prev).magnitude;
				if(dist >= dSpeed*Time.deltaTime)
				{
					finished = true;
				} else prev = pathToFollow.GetPoint (t);
			}

			Vector3 currentPoint = pathToFollow.GetPoint(t);
			this.transform.position = currentPoint;

			switch(mode)
			{
				case TrackingMode.FixedDirection:
					this.transform.LookAt(currentPoint + directionToLook);
					break;
				case TrackingMode.RollerCoaster:
					this.transform.LookAt(2*currentPoint-lastPoint);
					break;
				case TrackingMode.Observe:
					this.transform.LookAt(objectToFollow.transform.position);
					break;
				case TrackingMode.Track:
					this.transform.LookAt(2*currentPoint-lastPoint);
					break;
			}
			//Debug.Log ("Current Speed: " + ((currentPoint-lastPoint).magnitude/Time.deltaTime).ToString());
			lastPoint = currentPoint;
		}
	}
}
