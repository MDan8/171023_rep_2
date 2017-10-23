using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour {
	public int rule = 1;
	public int level = 1;


	public int ready = 0;
	GameObject backbutton2;
	GameObject clearwindow;
	GameObject misswindow;
	GameObject ClearText;
	GameObject cue;
	GameObject bil0;
	GameObject bil1;
	GameObject bil2;
	GameObject bil3;
	GameObject bil4;
	GameObject bil5;
	GameObject bil6;
	GameObject bil7;
	GameObject bil8;
	GameObject bil9;

	Vector2 temp0Pos = new Vector2 (-4f, 0);
	Vector2 temp1Pos = new Vector2 (4f, 0);
	Vector2 temp2Pos = new Vector2 (5.04f, -0.6f);
	Vector2 temp3Pos = new Vector2 (6.08f, 0);
	Vector2 temp4Pos = new Vector2 (5.04f, 0.6f);
	Vector2 temp5Pos = new Vector2 (4.52f, -0.3f);
	Vector2 temp6Pos = new Vector2 (5.56f, -0.3f);
	Vector2 temp7Pos = new Vector2 (5.56f, 0.3f);
	Vector2 temp8Pos = new Vector2 (4.52f, 0.3f);
	Vector2 temp9Pos = new Vector2 (5.04f, 0);

	Vector2 oPos = new Vector2 (0, 0);
	Vector2 mPos = new Vector2 (0, 0);
	float dx = 0;
	float dy = 0;

	int setBall = 0;
	public bool bil0Fall = false;
	public bool clicked = false;
	bool gameClear = false;
	bool gameFail = false;

	float delta = 0;

	public List<GameObject> bilList = new List<GameObject>();
	public List<int> onBoard = new List<int> ();
	public int minNum = 10;
	public int hitWallNum = 0;

	// Use this for initialization
	void Start () {
		this.backbutton2 = GameObject.Find ("Button");
		backbutton2.SetActive (false);
		this.clearwindow = GameObject.Find ("clearwindow");
		this.misswindow = GameObject.Find ("misswindow");
		this.ClearText = GameObject.Find ("ClearText");
		this.rule = MenuDirector.getRule();
		this.level = MenuDirector.getLevel();
		this.cue = GameObject.Find ("cue");
		this.bil0 = GameObject.Find ("bil0");
		this.bil1 = GameObject.Find ("bil1");
		this.bil2 = GameObject.Find ("bil2");
		this.bil3 = GameObject.Find ("bil3");
		this.bil4 = GameObject.Find ("bil4");
		this.bil5 = GameObject.Find ("bil5");
		this.bil6 = GameObject.Find ("bil6");
		this.bil7 = GameObject.Find ("bil7");
		this.bil8 = GameObject.Find ("bil8");
		this.bil9 = GameObject.Find ("bil9");
		for (int i = 1; i <= 9; i++) {
			onBoard.Add (i);
		}
		Debug.Log (onBoard.Count + " " + rule + " " + level);
	}
	
	// Update is called once per frame
	void Update () {
		if (cue.GetComponent<CueController> ().canMove == -1) {
			mPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			oPos = bil0.transform.position;
			Behaviour bh = (Behaviour)bil0.GetComponent ("Halo");
			if (Mathf.Pow (mPos.x - oPos.x, 2) + Mathf.Pow (mPos.y - oPos.y, 2) < 2) {
				bh.enabled = true;
			} else {
				bh.enabled = false;
			}
			if (Mathf.Pow (mPos.x - oPos.x, 2) + Mathf.Pow (mPos.y - oPos.y, 2) < 2 && setBall == 0 && Input.GetMouseButtonDown (0)) {
				setBall = 1;
				dx = mPos.x - oPos.x;
				dy = mPos.y - oPos.y;
			}
			if (setBall > 0 ) {
				if (mPos.x - dx < -3.9f && mPos.x - dx > -6.8f) {
					oPos.x = mPos.x - dx;
				} else if (mPos.x - dx >= -3.9f) {
					oPos.x = -3.9f;
				} else {
					oPos.x = -6.8f;
				}
				if (mPos.y - dy < 3.3f && mPos.y - dy > -3.3f) {
					oPos.y = mPos.y - dy;
				} else if (mPos.y - dy >= 3.3f) {
					oPos.y = 3.3f;
				} else {
					oPos.y = -3.3f;
				}
				
				bil0.transform.position = oPos;
				delta += Time.deltaTime;
				if (delta > 0.5f) {
					setBall = 2;
				}
			}
			if (setBall == 2 && Input.GetMouseButtonDown (0)) {
				delta = 0;
				setBall = 0;
				cue.GetComponent<CueController> ().canMove = 0;
			}
		}


		if (cue.GetComponent<CueController> ().canMove == 5) {
			if (bil0.GetComponent<Rigidbody2D> ().velocity.magnitude == 0 &&
			    bil1.GetComponent<Rigidbody2D> ().velocity.magnitude == 0 &&
			    bil2.GetComponent<Rigidbody2D> ().velocity.magnitude == 0 &&
			    bil3.GetComponent<Rigidbody2D> ().velocity.magnitude == 0 &&
			    bil4.GetComponent<Rigidbody2D> ().velocity.magnitude == 0 &&
			    bil5.GetComponent<Rigidbody2D> ().velocity.magnitude == 0 &&
			    bil6.GetComponent<Rigidbody2D> ().velocity.magnitude == 0 &&
			    bil7.GetComponent<Rigidbody2D> ().velocity.magnitude == 0 &&
			    bil8.GetComponent<Rigidbody2D> ().velocity.magnitude == 0 &&
			    bil9.GetComponent<Rigidbody2D> ().velocity.magnitude == 0) {
				bil0.GetComponent<BilController> ().notHitYet = true;
				this.delta += Time.deltaTime;
				if (this.delta > 1) {
					Debug.Log (hitWallNum);
					Judge();
					this.hitWallNum = 0;
					bil0.GetComponent<BilController> ().notHitWall = true;
					bil1.GetComponent<BilController> ().notHitWall = true;
					bil2.GetComponent<BilController> ().notHitWall = true;
					bil3.GetComponent<BilController> ().notHitWall = true;
					bil4.GetComponent<BilController> ().notHitWall = true;
					bil5.GetComponent<BilController> ().notHitWall = true;
					bil6.GetComponent<BilController> ().notHitWall = true;
					bil7.GetComponent<BilController> ().notHitWall = true;
					bil8.GetComponent<BilController> ().notHitWall = true;
					bil9.GetComponent<BilController> ().notHitWall = true;
					cue.GetComponent<CueController> ().canMove = 0;
					cue.SetActive (true);
					this.delta = 0;
					if (gameClear) {
						cue.GetComponent<CueController> ().canMove = 6;
						clearwindow.GetComponent<SpriteRenderer> ().sortingOrder = 3;
						this.ClearText.GetComponent<Text> ().text = cue.GetComponent<CueController> ().count + "";
						backbutton2.SetActive (true);
					}
					if (gameFail) {
						cue.GetComponent<CueController> ().canMove = 6;
						misswindow.GetComponent<SpriteRenderer> ().sortingOrder = 3;
						backbutton2.SetActive (true);
					}
				}
			}
		}
	}

	public void SelectMinNum() {
		this.minNum = 10;
		foreach (int i in onBoard) {
			if (minNum > i)
				minNum = i;
		}
	}

		
	//ルール難易度ごと

	void Judge () {
		if (((level == 1 || level == 2) && bil0Fall) ||
		    (level == 2 && bil0.GetComponent<BilController> ().firstHitNum != this.minNum) ||
		    (level == 2 && hitWallNum == 0) ||
		    (level == 2 && cue.GetComponent<CueController> ().brkshot == 1 && hitWallNum < 4 && bilList.Count == 0)) {
			foreach (GameObject bils in bilList) {
				bils.SetActive (true);
			}
			bil0.transform.position = temp0Pos;
			bil1.transform.position = temp1Pos;
			bil2.transform.position = temp2Pos;
			bil3.transform.position = temp3Pos;
			bil4.transform.position = temp4Pos;
			bil5.transform.position = temp5Pos;
			bil6.transform.position = temp6Pos;
			bil7.transform.position = temp7Pos;
			bil8.transform.position = temp8Pos;
			bil9.transform.position = temp9Pos;
			bil0Fall = false;
			bilList.Clear ();
			if (cue.GetComponent<CueController> ().brkshot == 1) {
				cue.GetComponent<CueController> ().brkshot = 0;
			}
		} else if ((level == 1 && bil0.GetComponent<BilController> ().firstHitNum != this.minNum) ||
		           (level == 1 && hitWallNum == 0) ||
		           (level == 1 && cue.GetComponent<CueController> ().brkshot == 1 && hitWallNum < 4 && bilList.Count == 0)) {
			foreach (GameObject bils in bilList) {
				switch (bils.transform.name) {
				case "bil1":
					onBoard.Remove (1);
					break;
				case "bil2":
					onBoard.Remove (2);
					break;
				case "bil3":
					onBoard.Remove (3);
					break;
				case "bil4":
					onBoard.Remove (4);
					break;
				case "bil5":
					onBoard.Remove (5);
					break;
				case "bil6":
					onBoard.Remove (6);
					break;
				case "bil7":
					onBoard.Remove (7);
					break;
				case "bil8":
					onBoard.Remove (8);
					break;
				case "bil9":
					onBoard.Remove (9);
					break;
				}
			}
			temp0Pos = bil0.transform.position;
			temp1Pos = bil1.transform.position;
			temp2Pos = bil2.transform.position;
			temp3Pos = bil3.transform.position;
			temp4Pos = bil4.transform.position;
			temp5Pos = bil5.transform.position;
			temp6Pos = bil6.transform.position;
			temp7Pos = bil7.transform.position;
			temp8Pos = bil8.transform.position;
			temp9Pos = bil9.transform.position;
			bilList.Clear ();
			cue.GetComponent<CueController> ().count++;
		} else if (level == 3 &&
			(bil0.GetComponent<BilController> ().firstHitNum != this.minNum || hitWallNum == 0 || bil0Fall ||
		          (cue.GetComponent<CueController> ().brkshot == 1 && hitWallNum < 4 && bilList.Count == 0))) {
			gameFail = true;
			bil0Fall = false;
			bilList.Clear ();
		} else {
			foreach (GameObject bils in bilList) {
				switch (bils.transform.name) {
				case "bil1":
					onBoard.Remove (1);
					break;
				case "bil2":
					onBoard.Remove (2);
					break;
				case "bil3":
					onBoard.Remove (3);
					break;
				case "bil4":
					onBoard.Remove (4);
					break;
				case "bil5":
					onBoard.Remove (5);
					break;
				case "bil6":
					onBoard.Remove (6);
					break;
				case "bil7":
					onBoard.Remove (7);
					break;
				case "bil8":
					onBoard.Remove (8);
					break;
				case "bil9":
					onBoard.Remove (9);
					break;
				}
			}
			temp0Pos = bil0.transform.position;
			temp1Pos = bil1.transform.position;
			temp2Pos = bil2.transform.position;
			temp3Pos = bil3.transform.position;
			temp4Pos = bil4.transform.position;
			temp5Pos = bil5.transform.position;
			temp6Pos = bil6.transform.position;
			temp7Pos = bil7.transform.position;
			temp8Pos = bil8.transform.position;
			temp9Pos = bil9.transform.position;
			bilList.Clear ();
		}
		if (onBoard.IndexOf (9) == -1) {
			gameClear = true;
		}
	}

	public void BackButtonDown() {
		SceneManager.LoadScene ("MenuScene");
	}
}
