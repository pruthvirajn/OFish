using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankCollide : MonoBehaviour {
	public static int waterDrops;
	public AudioSource goodSound;
	public AudioSource badSound;
	public  Text score;
	public Text good;
	public Text bad;
	int goodDrops = 0;
	int badDrops = 0;
	public Material highLife;
	public Material mediumLife;
	public Material lowLife;
	public GameObject fishBody;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider target){
		if (target.gameObject.name == "BadDrop(Clone)") {
			badSound.Play ();
			--waterDrops;
			++badDrops;
			bad.text = ""+badDrops;
		} else if (target.gameObject.name == "Drop(Clone)") {
			goodSound.Play ();
			++waterDrops;
			++goodDrops;
			good.text = ""+goodDrops;
			score.text = ""+goodDrops * 20;
		}
		if (badDrops > 10 && goodDrops < 10) {
			fishBody.GetComponent<Renderer> ().material = lowLife;
		}
		if (badDrops < 10 && goodDrops > 10) {
			fishBody.GetComponent<Renderer> ().material = highLife;
		}
		if (badDrops < 5 && goodDrops < 5) {
			fishBody.GetComponent<Renderer> ().material = mediumLife;
		}
		Debug.Log ("Collided val: "+waterDrops);
		Destroy (target.gameObject);
	}
}
