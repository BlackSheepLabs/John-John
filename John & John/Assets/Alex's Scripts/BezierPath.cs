using UnityEngine;
using System.Collections;

public class BezierPath : MonoBehaviour {

	public GameObject[] Points;
	Vector3[] bezierPoints;
	int pointCount;
	public float[] pathLength;
	public float totalLength;
	float tMod;
	// Use this for initialization
	public void Start () {
		pointCount = 2*Points.Length-3;
		bezierPoints = new Vector3[pointCount];
		pathLength = new float[Points.Length-2];
		bezierPoints[0] = Points[0].transform.position;
		bezierPoints[1] = Points[1].transform.position;
		bezierPoints[pointCount-1] = Points[Points.Length-1].transform.position;
		for(int i = 2;  i < Points.Length; ++i)
		{
			bezierPoints[2*i-2] = Points[i].transform.position;
			if(i < Points.Length-1)
			{
				bezierPoints[2*i-1] = ((bezierPoints[2*i-2]-bezierPoints[2*i-3]).magnitude+(bezierPoints[2*i-3]-bezierPoints[2*i-4]).magnitude)*0.4f
					*(bezierPoints[2*i-2]-bezierPoints[2*i-3]).normalized+Points[i].transform.position;
			}
		}
		updatePath ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void updatePath(bool calcVals = true)
	{
		if(calcVals) tMod = 0;
		for(int i = 0; i < pointCount-2; i += 2)
		{
			if(calcVals) pathLength[i/2] = 0.0f;
			Vector3 currentPoint, prevPoint;
			prevPoint = bezierPoints[i];
			if(calcVals) tMod += 1;

			for(float t = 0.01f; t < 1.005f;t += 0.01f)
			{
				currentPoint = t*t*bezierPoints[i+2]+2*t*(1-t)*bezierPoints[i+1]+(1-t)*(1-t)*bezierPoints[i];
				if(calcVals) pathLength[i/2] += (currentPoint-prevPoint).magnitude;
				Debug.DrawLine(prevPoint,currentPoint);
				prevPoint = currentPoint;
			}
			if(calcVals) totalLength += pathLength[i/2];
		}

		if(calcVals) tMod = 1/tMod;
	}

	public float GetLength(float t)
	{
		int i = 0;
		while(t > tMod) {t -= tMod; i += 1;}
		return pathLength[i]*pathLength.Length;
	}

	public Vector3 GetPoint(float t)
	{
		int i = 0;
		while(t > tMod) {t -= tMod; i += 2;}
		t = t/tMod;
		Vector3 currentPoint = Vector3.zero;

		if(i < bezierPoints.Length-2)
		{currentPoint = t*t*bezierPoints[i+2]+2*t*(1-t)*bezierPoints[i+1]+(1-t)*(1-t)*bezierPoints[i];}
		else {currentPoint = bezierPoints[pointCount-1];}
		return currentPoint;
	}
}
