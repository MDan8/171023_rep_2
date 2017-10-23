using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDirector : MonoBehaviour {

	public int rule = 0;
	public int level = 0;

	public static int gameRule = 0;
	public static int gameLevel = 0;

	GameObject bilmenu1;
	GameObject button4;
	GameObject button5;
	GameObject button6;
	GameObject button7;
	GameObject button8;

	// Use this for initialization
	void Start () {
		this.bilmenu1 = GameObject.Find ("bilmenu1");
		this.button4 = GameObject.Find ("button4");
		this.button5 = GameObject.Find ("button5");
		this.button6 = GameObject.Find ("button6");
		this.button7 = GameObject.Find ("button7");
		this.button8 = GameObject.Find ("button8");
		button6.SetActive (false);
		button7.SetActive (false);
		button8.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void nBallButtonDown() {
		this.rule = 1;
		bilmenu1.SetActive (false);
		button4.SetActive (false);
		button5.SetActive (false);
		button6.SetActive (true);
		button7.SetActive (true);
		button8.SetActive (true);
	}

	public void Confirm() {
		gameRule = this.rule;
		gameLevel = this.level;
	}

	public static int getRule() {
		return gameRule;
	}

	public static int getLevel() {
		return gameLevel;
	}
}
