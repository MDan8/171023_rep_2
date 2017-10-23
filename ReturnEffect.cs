using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnEffect : MonoBehaviour {
	GameObject GameDirector;
	GameObject cue;
	GameObject window1;
	GameObject yesbutton;
	GameObject nobutton;


	// Use this for initialization
	void Start () {
		this.GameDirector = GameObject.Find ("GameDirector");
		this.cue = GameObject.Find ("cue");
		this.window1 = GameObject.Find ("window1");
		this.yesbutton = GameObject.Find ("yesbutton");
		this.nobutton = GameObject.Find ("nobutton");
		GameDirector.GetComponent<GameDirector> ().ready++;
		if(GameDirector.GetComponent<GameDirector> ().ready >= 3) {
			yesbutton.SetActive (false);
			nobutton.SetActive (false);
		}
	}
	
	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0) && this.tag == "backbutton2") {
			GameDirector.GetComponent<GameDirector>().clicked = true;
			cue.GetComponent<CueController> ().tempcanMove = cue.GetComponent<CueController> ().canMove;
			cue.GetComponent<CueController> ().canMove = -2;
			window1.GetComponent<SpriteRenderer> ().sortingOrder = 2;
			yesbutton.SetActive (true);
			nobutton.SetActive (true);
			yesbutton.GetComponent<SpriteRenderer> ().sortingOrder = 3;
			nobutton.GetComponent<SpriteRenderer> ().sortingOrder = 3;
		}

		if (Input.GetMouseButtonDown (0) && this.tag == "backyes") {
			GameDirector.GetComponent<GameDirector>().clicked = false;
			SceneManager.LoadScene ("MenuScene");
			yesbutton.SetActive (false);
			nobutton.SetActive (false);
		}

		if (Input.GetMouseButtonDown (0) && this.tag == "backno") {
			GameDirector.GetComponent<GameDirector>().clicked = false;
			cue.GetComponent<CueController> ().canMove = cue.GetComponent<CueController> ().tempcanMove;
			Debug.Log (cue.GetComponent<CueController> ().canMove);
			window1.GetComponent<SpriteRenderer> ().sortingOrder = -2;
			yesbutton.SetActive (false);
			nobutton.SetActive (false);
		}
	}
}
