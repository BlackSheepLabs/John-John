using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(PowerCube))]
public class PowerCubeEditor : Editor {

	public override void OnInspectorGUI()
	{
		PowerCube t = (PowerCube)target;
		t.IsAlwaysActive = EditorGUILayout.ToggleLeft("Is Always Active", t.IsAlwaysActive);

		serializedObject.Update();
		EditorGUILayout.PropertyField(serializedObject.FindProperty("responseTriggers"), true);
		serializedObject.ApplyModifiedProperties();

		EditorGUILayout.Space();
		t.activateSoundEffect = EditorGUILayout.ObjectField("Activate Sound Effect",
		                             t.activateSoundEffect, t.activateSoundEffect.GetType(),false) as AudioClip;
		t.activateSEDelay = EditorGUILayout.FloatField ("Activate SE Delay", t.activateSEDelay);
		t.deactivateSoundEffect = EditorGUILayout.ObjectField("Deactivate Sound Effect",
		                             t.deactivateSoundEffect, t.deactivateSoundEffect.GetType(),false) as AudioClip;
		t.deactivateSEDelay = EditorGUILayout.FloatField ("Deactivate SE Delay", t.deactivateSEDelay);

		EditorUtility.SetDirty(t);
	}

}
