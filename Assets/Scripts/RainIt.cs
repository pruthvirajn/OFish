using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainIt : MonoBehaviour {
	public GameObject goodDrop;
	public GameObject badDrop;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {

	}

	public void startRain(){
		StartCoroutine (dropDrops());
	}

	public void stopRain(){
		StopAllCoroutines ();
	}

	IEnumerator dropDrops(){
		for (int i = 0; i < 2000; i++) {
			yield return new WaitForSeconds (0.5f);
			for (int j = 0; j < 25; j++) {
				Vector3 position1 = new Vector3 (Random.Range (-0.5f, 0.5f), Random.Range (0f, 1.0f), Random.Range (-0.5f, 0.5f));
				GameObject drops1 = (GameObject) Instantiate (goodDrop, position1, Quaternion.identity);

				if (j % 3 == 0) {
					Vector3 position2 = new Vector3 (Random.Range (-0.5f, 0.5f), Random.Range (0f, 1.0f), Random.Range (-0.5f, 0.5f));
					GameObject drops2 = (GameObject)Instantiate (badDrop, position2, Quaternion.identity);
				}
			}
		}
	}
}
