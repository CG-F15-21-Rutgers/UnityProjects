using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonGUI : MonoBehaviour {

	void OnGUI()
	{
		if (GUI.Button (new Rect (650, 220, 150, 50), "Environment")) {
			Application.LoadLevel (1);
		}
		if (GUI.Button (new Rect (650, 280, 150, 50), "Animations")) {
			Application.LoadLevel (2);
		}
		if (GUI.Button (new Rect (650, 340, 150, 50), "Play Game")) {
			Application.LoadLevel (3);
		}
		if (GUI.Button (new Rect (650, 400, 150, 50), "Quit Game")) {
			Application.Quit();

	}
}
}
