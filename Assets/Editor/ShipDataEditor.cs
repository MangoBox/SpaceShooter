using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ShipDataController))]
public class ShipDataEditor : EditorWindow {

	public SerializedProperty shipAcceleration;

	// Add menu named "My Window" to the Window menu
	[MenuItem("Window/My Window")]
	static void Init()
	{
		// Get existing open window or if none, make a new one:
		ShipDataEditor window = (ShipDataEditor)EditorWindow.GetWindow(typeof(ShipDataEditor));
		window.Show();
	}

	void OnGUI()
	{
		GUILayout.Label ("Base Settings", EditorStyles.boldLabel);
		//myString = EditorGUILayout.TextField ("Text Field", myString);
		EditorGUI.PropertyField(new Rect(0,300,500,30), shipAcceleration, new GUIContent("Acceleration: "));


		//EditorGUILayout.EndToggleGroup ();
	}
}
