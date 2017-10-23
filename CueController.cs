using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueController : MonoBehaviour {

	public int canMove = -1;
	public int tempcanMove = -1;
	public int count = 0;
	public int brkshot = 0;
	Vector2 oPos = new Vector2(0, 0);
	float difX = 0;
	float difY = 0;
	GameObject bil0;
	GameObject GameDirector;
	float delta = 0;
	public float ang = 0;
	float delta2 = 0;
	float delta3 = 0;
	public float forceSource = 0;

	// Use this for initialization
	void Start () {
		this.bil0 = GameObject.Find ("bil0");
		this.GameDirector = GameObject.Find ("GameDirector");
		canMove = -1;
	}



	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Space) && canMove == 0 && brkshot == 0) {
			canMove = -1;
		}
			
		if (Input.GetMouseButtonDown(0) && canMove == 0) {
			this.forceSource = 0;
			Vector2 mPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			oPos.x = transform.position.x;
			oPos.y = transform.position.y;


			Vector2 dir = oPos - mPos;

			if (dir.magnitude < 2.6f) {
				canMove = 1;
				difX = dir.x;
				difY = dir.y;
			}
		}

		if (Input.GetKeyDown (KeyCode.Return) && canMove == 0) {
			canMove = 2;
			oPos = transform.position;
			oPos.x = transform.position.x - Mathf.Cos (this.ang * Mathf.PI / 180);
			oPos.y = transform.position.y - Mathf.Sin (this.ang * Mathf.PI / 180);
			transform.position = oPos;
		}

		if(canMove == 1) {
			oPos = transform.position; 
			oPos.x = Camera.main.ScreenToWorldPoint (Input.mousePosition).x + difX;
			oPos.y = Camera.main.ScreenToWorldPoint (Input.mousePosition).y + difY;
			transform.position = oPos;

			float dx = bil0.transform.position.x - oPos.x;
			float dy = bil0.transform.position.y - oPos.y;
			this.ang = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
			this.transform.rotation = Quaternion.Euler(0,0,ang);
			Behaviour bh = (Behaviour)bil0.GetComponent ("Halo");

			if (Mathf.Pow (dx, 2) + Mathf.Pow (dy, 2) > 8 && Mathf.Pow (dx, 2) + Mathf.Pow (dy, 2) < 25) {
				bh.enabled = true;
			} else {
				bh.enabled = false;
			}

			this.delta += Time.deltaTime;

			if (Input.GetMouseButtonDown (0) && this.delta > 0.5f && bh.enabled) {
				canMove = 0;
				this.delta = 0;
			}

		}

		if (Input.GetMouseButtonDown (0) && (canMove == 2 || canMove == 3)) {
			this.forceSource = 0;
			this.delta2 = 0;
			oPos = transform.position;
			oPos.x = transform.position.x + Mathf.Cos (this.ang * Mathf.PI / 180);
			oPos.y = transform.position.y + Mathf.Sin (this.ang * Mathf.PI / 180);
			transform.position = oPos;
			canMove = 1;
		}

		if (canMove == 2) {
			this.delta2 += Time.deltaTime;
			if (this.delta2 > 0.5) {
				this.delta2 = 0;
				canMove = 3;
			}
		}

		if (canMove == 3 && forceSource <= 5) {
			this.forceSource += Time.deltaTime;
		}

		if (Input.GetKeyDown (KeyCode.Return) && canMove == 3) {
			count++;
			brkshot++;
			GameDirector.GetComponent<GameDirector> ().SelectMinNum ();
			oPos = transform.position;
			oPos.x = bil0.transform.position.x - 2.7f * Mathf.Cos (this.ang * Mathf.PI / 180);
			oPos.y = bil0.transform.position.y - 2.7f * Mathf.Sin (this.ang * Mathf.PI / 180);
			transform.position = oPos;
			canMove = 4;
		}

		if (canMove == 4) {
			this.delta3 += Time.deltaTime;
			if (delta3 > 1) {
				canMove = 5;
				gameObject.SetActive (false);
				this.delta3 = 0;
			}
		}
	}
}
