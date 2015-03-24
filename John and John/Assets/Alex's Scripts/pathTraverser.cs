using UnityEngine;
using System.Collections;

public class pathTraverser : MonoBehaviour {

	public float speed = 2.0f;
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
			while(t < 1.0f && !finished)
			{
				t += speed/(pathToFollow.GetLength(t)*20)*Time.deltaTime;
				if((pathToFollow.GetPoint (t)-lastPoint).sqrMagnitude >= speed*speed*Time.deltaTime*Time.deltaTime)
				{
					finished = true;
				}
			}
			Vector3 currentPoint = pathToFollow.GetPoint(t);
			this.transform.position = currentPoint;
			this.transform.LookAt(2*currentPoint-lastPoint);
			//Debug.Log ("Current Speed: " + ((currentPoint-lastPoint).magnitude/Time.deltaTime).ToString());
			lastPoint = currentPoint;
		}
	}
}
