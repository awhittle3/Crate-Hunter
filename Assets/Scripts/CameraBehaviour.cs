using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

	//Bounds of box that camera moves in
	private const float BOUNDS_X_UPPER = 10.0f;
	private const float BOUNDS_X_LOWER = 0.0f;
	private const float BOUNDS_Z_UPPER = 0.0f;
	private const float BOUNDS_Z_LOWER = -10.0f;
	
	private const float SPEED_ROT = 150.0f;
	private const float SPEED_LIN = 2.0f;
	
	void Start () {
	
	}

	void Update () {
		moveCamera ();
	}

	//Camera runs around on a rectangular path
	void moveCamera(){
		if (transform.position.x < BOUNDS_X_UPPER && transform.position.z >= BOUNDS_Z_UPPER) {
			transform.position += new Vector3(SPEED_LIN*Time.deltaTime,0.0f,0.0f);
		}

		if (transform.position.x >= BOUNDS_X_UPPER && transform.position.z > BOUNDS_Z_LOWER) {
			transform.position += new Vector3(0.0f,0.0f,-SPEED_LIN*Time.deltaTime);
		}

		if (transform.position.x > BOUNDS_X_LOWER && transform.position.z <= BOUNDS_Z_LOWER) {
			transform.position += new Vector3(-SPEED_LIN*Time.deltaTime,0.0f,0.0f);
		}

		if (transform.position.x <= BOUNDS_X_LOWER && transform.position.z < BOUNDS_Z_UPPER) {
			transform.position += new Vector3(0.0f,0.0f,SPEED_LIN*Time.deltaTime);
		}
	}

}
