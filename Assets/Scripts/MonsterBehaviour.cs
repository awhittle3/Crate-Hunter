using UnityEngine;
using System.Collections;

public class MonsterBehaviour : MonoBehaviour {

	private bool isHit = false;
	private const float SCALESPEED = 1.0f;
	private const float SCALE = 0.1f;
	private float timer = 0.0f;
	private const float MAXLIFE = 3.0f;

	void Update () {
		if (isHit) {
			transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(SCALE, SCALE, SCALE), Time.deltaTime*SCALESPEED);
			timer += Time.deltaTime;
		}

		if (timer >= MAXLIFE) {
			gameObject.SetActive(false);
		}
	}

	void OnTriggerEnter (Collider other) {
		isHit = true;
	}

}
