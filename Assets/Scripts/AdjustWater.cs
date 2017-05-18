using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustWater : MonoBehaviour {
	private bool first = false;
	private bool second = false;
	private bool third = false;
	private bool fourth = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 initScale;
		Vector3 initPos;

		if (TankCollide.waterDrops > 5 && TankCollide.waterDrops < 10 && !first) {
			first = true;
			initScale = transform.localScale;
			initScale.y += 5.0f;
			transform.localScale = initScale;

			initPos = transform.localPosition;
			initPos.z += -0.01f;
			transform.position = initPos;
		}
		if (TankCollide.waterDrops > 10 && TankCollide.waterDrops < 15 && !second) {
			second = true;
			initScale = transform.localScale;
			initScale.y += 5.0f;
			transform.localScale = initScale;

			initPos = transform.localPosition;
			initPos.z += -0.01f;
			transform.position = initPos;
		}
		if (TankCollide.waterDrops < -5 && TankCollide.waterDrops > -10 && !third) {
			third = true;
			initScale = transform.localScale;
			initScale.y += 5.0f;
			transform.localScale = initScale;

			initPos = transform.localPosition;
			initPos.z += -0.01f;
			transform.position = initPos;
		}
		if (TankCollide.waterDrops < -10 && TankCollide.waterDrops > -15 && !fourth) {
			fourth = true;
			initScale = transform.localScale;
			initScale.y += 5.0f;
			transform.localScale = initScale;

			initPos = transform.localPosition;
			initPos.z += -0.01f;
			transform.position = initPos;
		}
	}
}
