using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(BezierPath))]
public class BezierRenderer : Editor {
	/*
	void OnEnable()
	{((BezierPath)target).Start();}

	// Use this for initialization
	void OnSceneGUI() {
		BezierPath renderTarget = ((BezierPath)target);
		Vector3 lastPoint = renderTarget.GetPoint(0);
		for(float t = 0.01f; t < 1.0f; t += 0.01f)
		{
			Vector3 currentPoint = renderTarget.GetPoint(t);
			Handles.DrawLine(lastPoint,currentPoint);
			lastPoint = currentPoint;
		}
	}*/

	[DrawGizmo(GizmoType.NotSelected)]
	static void RenderCustomGizmo(Transform objectTransform, GizmoType gizmoType)
	{
		BezierPath renderTarget = objectTransform.GetComponent<BezierPath>();

		if(renderTarget != null)
		{
			renderTarget.Start();
		}
	}
}
