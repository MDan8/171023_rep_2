using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hallEffect : MonoBehaviour {
	GameObject GameDirector;
	Vector3 stay = new Vector3(0,0,0);

	void Start () {
		this.GameDirector = GameObject.Find ("GameDirector");
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag != "cue") {
			other.gameObject.GetComponent<Rigidbody2D>().velocity = stay;
			if (other.gameObject.tag == "Bil0") {
				GameDirector.GetComponent<GameDirector> ().bil0Fall = true;
			} 
			GameDirector.GetComponent<GameDirector> ().bilList.Add (other.gameObject);
			other.gameObject.SetActive (false);
		}
	}
}
