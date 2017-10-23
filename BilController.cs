using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilController : MonoBehaviour {
	Rigidbody2D rigid2D;
	GameObject cue;
	GameObject GameDirector;
	int check = 0;
	float plusforce = 0;
	float maxForce = 1000.0f;
	float floorflc = -2.5f;
	float ang = 0;
	float forceSource = 0;
	Vector3 stay = new Vector3(0,0,0);
	public bool notHitYet = true;
	public int firstHitNum = 0;
	public bool notHitWall = true;


	// Use this for initialization
	void Start () {
		this.rigid2D = GetComponent<Rigidbody2D> (); 
		this.cue = GameObject.Find ("cue");
		this.GameDirector = GameObject.Find ("GameDirector");
	}
	
	// Update is called once per frame
	void Update () {
		if (cue.GetComponent<CueController> ().canMove == 4 && check == 0 && this.gameObject.tag =="Bil0") {
			this.ang = cue.GetComponent<CueController> ().ang;
			this.forceSource = cue.GetComponent<CueController> ().forceSource;
			this.plusforce = this.maxForce * (1 -  this.forceSource / 10);
			this.rigid2D.AddForce (transform.right * this.plusforce * Mathf.Cos(this.ang * Mathf.PI / 180));
			this.rigid2D.AddForce (transform.up * this.plusforce * Mathf.Sin(this.ang * Mathf.PI / 180));
			check = 1;
		}
		//if (check == 1 && this.rigid2D.velocity.x != 0) {
		//	this.rigid2D.AddForce (transform.right * this.floorflc * Mathf.Cos(this.ang * Mathf.PI / 180));
		//	this.rigid2D.AddForce (transform.up * this.floorflc * Mathf.Sin(this.ang * Mathf.PI / 180));

		//}

		if (rigid2D.velocity.magnitude > 0.05) {
			check = 2;
			float vx = rigid2D.velocity.x;
			float vy = rigid2D.velocity.y;
			this.rigid2D.AddForce (transform.right * this.floorflc * vx / (Mathf.Abs(vx) + Mathf.Abs(vy)));
			this.rigid2D.AddForce (transform.up * this.floorflc * vy / (Mathf.Abs(vx) + Mathf.Abs(vy)));

		}

		if (rigid2D.velocity.magnitude <= 0.05 && check == 2) {
			check = 0;
			this.rigid2D.velocity = stay;
		}

	}

	void OnCollisionEnter2D(Collision2D other) {
		if (this.gameObject.tag == "Bil0" && notHitYet == true) {
			switch (other.gameObject.tag) {
			case "Bil1":
				firstHitNum = 1;
				notHitYet = false;
				break;
			case "Bil2":
				firstHitNum = 2;
				notHitYet = false;
				break;
			case "Bil3":
				firstHitNum = 3;
				notHitYet = false;
				break;
			case "Bil4":
				firstHitNum = 4;
				notHitYet = false;
				break;
			case "Bil5":
				firstHitNum = 5;
				notHitYet = false;
				break;
			case "Bil6":
				firstHitNum = 6;
				notHitYet = false;
				break;
			case "Bil7":
				firstHitNum = 7;
				notHitYet = false;
				break;
			case "Bil8":
				firstHitNum = 8;
				notHitYet = false;
				break;
			case "Bil9":
				firstHitNum = 9;
				notHitYet = false;
				break;
			}
		}

		if (other.gameObject.tag == "WallorHall" && notHitWall) {
			GameDirector.GetComponent<GameDirector> ().hitWallNum++;
			notHitWall = false;
		}
	}
}
