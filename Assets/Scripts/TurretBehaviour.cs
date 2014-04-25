using UnityEngine;
using System.Collections;

public class TurretBehaviour : MonoBehaviour {

	public GameObject missile;
	public Camera FPS;
	public Light missileLight;
	private const float RELOAD_TIME = 0.5f;
	private const float MSPEED_LIN = 5.0f;
	private Vector3 target;
	private Vector3 direction;
	private bool missileAlive;
	private float lifeTimer = 0.0f;
	private const float MAXLIFE = 2.0f;

	void Start () {
		missileAlive = false;
		toggleMissile (missileAlive);
	}
	

	void Update () {
		turretLookAt ();
		FPS.transform.position = transform.position;

		if(Input.GetMouseButtonDown(0) && !missileAlive){
			armMissile ();
			missile.audio.Play();
		}
		if (missileAlive) {
			lifeTimer += Time.deltaTime;
			missile.transform.position += direction.normalized * MSPEED_LIN * Time.deltaTime;
			missileLight.transform.position = missile.transform.position;
		}

		if (lifeTimer >= MAXLIFE) {
			missileAlive = false;
			toggleMissile (missileAlive);
			lifeTimer = 0.0f;
		}
	}

	void turretLookAt(){
		Vector3 mousePos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0.0f);
		Vector3 lookAtPos = Camera.main.WorldToScreenPoint(transform.position) - mousePos;
		transform.LookAt (lookAtPos);
		transform.rotation = Quaternion.FromToRotation(Vector3.up, Vector3.forward) * transform.rotation;

		Vector3 FPSLookAtPos = -switchYZ (lookAtPos);
		FPS.transform.LookAt (FPSLookAtPos);
	}

	Vector3 missileLookAt(){
		Vector3 mousePos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0.0f);
		Vector3 lookAtPos = Camera.main.WorldToScreenPoint(transform.position) - mousePos;
		missile.transform.LookAt (lookAtPos);
		missile.transform.rotation = Quaternion.FromToRotation(Vector3.up, Vector3.forward) * missile.transform.rotation;
		missile.transform.rotation = Quaternion.FromToRotation(Vector3.left, Vector3.forward) * missile.transform.rotation;
		return lookAtPos;
	}

	void toggleMissile (bool tog){
		missile.SetActive(tog);
		missileLight.enabled = tog;
	}

	void armMissile (){
		missileAlive = true;
		toggleMissile (missileAlive);
		missile.transform.position = transform.position;

		target = missileLookAt ();
		direction = transform.position - target;
		direction = switchYZ (direction);
		missileLight.transform.position = missile.transform.position;
	}

	Vector3 switchYZ (Vector3 v)
	{
		Vector3 a = new Vector3 (v.x, 0.0f, v.y);
		return a;
	}
}
