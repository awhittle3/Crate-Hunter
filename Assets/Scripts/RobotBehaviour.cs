using UnityEngine;
using System.Collections;

public class RobotBehaviour : MonoBehaviour {

	//Bounds of box that robot moves in
	private const float BOUNDS_X_UPPER = 10.0f;
	private const float BOUNDS_X_LOWER = 0.0f;
	private const float BOUNDS_Z_UPPER = 0.0f;
	private const float BOUNDS_Z_LOWER = -10.0f;

	private const float SPEED_ROT = 150.0f;	//Rotation speed of robot
	private const float SPEED_LIN = 2.0f;	//Linear speed of robot
	

	void Update () {
		moveRobot ();
	}

	void moveRobot(){
		if (transform.position.x < BOUNDS_X_UPPER && transform.position.z >= BOUNDS_Z_UPPER) {
			transform.position += new Vector3(SPEED_LIN*Time.deltaTime,0.0f,0.0f);
		}
		if (transform.position.x >= BOUNDS_X_UPPER && (transform.eulerAngles.y < 90f || transform.eulerAngles.y >=360.0f)){
			if (transform.eulerAngles.y >= 360.0f) {
				transform.eulerAngles -= new Vector3(0.0f, 360.0f, 0.0f);
			}
			transform.eulerAngles += new Vector3(0.0f,SPEED_ROT*Time.deltaTime, 0.0f);
		}

		if (transform.position.x >= BOUNDS_X_UPPER && transform.position.z > BOUNDS_Z_LOWER) {
			transform.position += new Vector3(0.0f,0.0f,-SPEED_LIN*Time.deltaTime);
		}
		if (transform.position.z <= BOUNDS_Z_LOWER && transform.eulerAngles.y < 180f){
			transform.eulerAngles += new Vector3(0.0f,SPEED_ROT*Time.deltaTime, 0.0f);
		}

		if (transform.position.x > BOUNDS_X_LOWER && transform.position.z <= BOUNDS_Z_LOWER) {
			transform.position += new Vector3(-SPEED_LIN*Time.deltaTime,0.0f,0.0f);
		}
		if (transform.position.x <= BOUNDS_X_LOWER && transform.eulerAngles.y < 270f){
			transform.eulerAngles += new Vector3(0.0f,SPEED_ROT*Time.deltaTime, 0.0f);
		}
		
		if (transform.position.x <= BOUNDS_X_LOWER && transform.position.z < BOUNDS_Z_UPPER) {
			transform.position += new Vector3(0.0f,0.0f,SPEED_LIN*Time.deltaTime);
		}
		if (transform.position.z >= BOUNDS_Z_UPPER && transform.eulerAngles.y < 360f && transform.eulerAngles.y >=270f){
			transform.eulerAngles += new Vector3(0.0f,SPEED_ROT*Time.deltaTime, 0.0f);
		}


	}
}
