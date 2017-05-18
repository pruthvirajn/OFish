using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDrops : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 5.0f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate(Vector3.down * Time.deltaTime / 8);
	}
}
