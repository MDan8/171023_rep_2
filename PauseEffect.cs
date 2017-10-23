using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseEffect : MonoBehaviour {
	GameObject GameDirector;
	GameObject cue;
	GameObject window2;
	GameObject Turn;
	GameObject Text1;
	GameObject bil1sub;
	GameObject bil2sub;
	GameObject bil3sub;
	GameObject bil4sub;
	GameObject bil5sub;
	GameObject bil6sub;
	GameObject bil7sub;
	GameObject bil8sub;
	GameObject bil9sub;
	int minNum = 10;

	// Use this for initialization
	void Start () {
		this.GameDirector = GameObject.Find ("GameDirector");
		this.cue = GameObject.Find ("cue");
		this.window2 = GameObject.Find ("window2");
		this.Turn = GameObject.Find ("Turn");
		this.Text1 = GameObject.Find ("Text1");
		this.bil1sub = GameObject.Find ("bil1sub");
		this.bil2sub = GameObject.Find ("bil2sub");
		this.bil3sub = GameObject.Find ("bil3sub");
		this.bil4sub = GameObject.Find ("bil4sub");
		this.bil5sub = GameObject.Find ("bil5sub");
		this.bil6sub = GameObject.Find ("bil6sub");
		this.bil7sub = GameObject.Find ("bil7sub");
		this.bil8sub = GameObject.Find ("bil8sub");
		this.bil9sub = GameObject.Find ("bil9sub");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseEnter() {
		if (GameDirector.GetComponent<GameDirector> ().clicked == false && cue.GetComponent<CueController> ().canMove < 4) {
			window2.GetComponent<SpriteRenderer> ().sortingOrder = 2;
			this.Text1.GetComponent<Text> ().text = "最少番号の的球";
			this.Turn.GetComponent<Text> ().text = cue.GetComponent<CueController> ().count + 1 + "打目";
			minNum = 10;
			foreach (int i in GameDirector.GetComponent<GameDirector>().onBoard) {
				if (minNum > i) {
					minNum = i;
				}
			}
			switch (minNum) {
			case 1:
				bil1sub.GetComponent<SpriteRenderer> ().sortingOrder = 3;
				break;
			case 2:
				bil2sub.GetComponent<SpriteRenderer> ().sortingOrder = 3;
				break;
			case 3:
				bil3sub.GetComponent<SpriteRenderer> ().sortingOrder = 3;
				break;
			case 4:
				bil4sub.GetComponent<SpriteRenderer> ().sortingOrder = 3;
				break;
			case 5:
				bil5sub.GetComponent<SpriteRenderer> ().sortingOrder = 3;
				break;
			case 6:
				bil6sub.GetComponent<SpriteRenderer> ().sortingOrder = 3;
				break;
			case 7:
				bil7sub.GetComponent<SpriteRenderer> ().sortingOrder = 3;
				break;
			case 8:
				bil8sub.GetComponent<SpriteRenderer> ().sortingOrder = 3;
				break;
			case 9:
				bil9sub.GetComponent<SpriteRenderer> ().sortingOrder = 3;
				break;
			}
		}
	}

	void OnMouseExit() {
		bil1sub.GetComponent<SpriteRenderer> ().sortingOrder = -2;
		bil2sub.GetComponent<SpriteRenderer> ().sortingOrder = -2;
		bil3sub.GetComponent<SpriteRenderer> ().sortingOrder = -2;
		bil4sub.GetComponent<SpriteRenderer> ().sortingOrder = -2;
		bil5sub.GetComponent<SpriteRenderer> ().sortingOrder = -2;
		bil6sub.GetComponent<SpriteRenderer> ().sortingOrder = -2;
		bil7sub.GetComponent<SpriteRenderer> ().sortingOrder = -2;
		bil8sub.GetComponent<SpriteRenderer> ().sortingOrder = -2;
		bil9sub.GetComponent<SpriteRenderer> ().sortingOrder = -2;
		window2.GetComponent<SpriteRenderer> ().sortingOrder = -2;
		this.Text1.GetComponent<Text> ().text = "";
		this.Turn.GetComponent<Text> ().text = "";
	}
}
