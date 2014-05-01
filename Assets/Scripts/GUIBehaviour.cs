using UnityEngine;
using System.Collections;

public class GUIBehaviour : MonoBehaviour {

	private int frameCount = 0;
	private float nextUpdate = 0.0f;
	private float fps = 0.0f;
	private const float UPDATE_RATE = 1.0f;
	public GUIStyle style;
	private string sFPS;

	void Start () {
		nextUpdate = Time.time;
	}

	void Update () {
		frameCount++;
		if (Time.time > nextUpdate) {
			//Calculate frames per second
			nextUpdate += 1.0f/UPDATE_RATE;
			fps = frameCount * UPDATE_RATE;
			frameCount = 0;
		}

	}

	void OnGUI() {
		//Print frames per second
		sFPS = "FPS: " + fps.ToString ();
		GUI.Label (new Rect(Screen.width - 100, 0, 100, 80), sFPS, style);

	}
}
