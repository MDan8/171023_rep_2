using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEffect : MonoBehaviour {

	GameObject MenuDirector;
	GameObject bilmenu1;
	GameObject button4;
	GameObject button5;
	GameObject button6;
	GameObject button7;
	GameObject button8;

	// Use this for initialization
	void Start () {
		this.MenuDirector = GameObject.Find ("MenuDirector");
		this.bilmenu1 = GameObject.Find ("bilmenu1");
		this.button4 = GameObject.Find ("button4");
		this.button5 = GameObject.Find ("button5");
		this.button6 = GameObject.Find ("button6");
		this.button7 = GameObject.Find ("button7");
		this.button8 = GameObject.Find ("button8");
	}
	

	void OnMouseOver() {
		if(Input.GetMouseButtonDown(0) && this.tag == "button4") {
			MenuDirector.GetComponent<MenuDirector>().rule = 1;
			bilmenu1.SetActive (false);
			button4.SetActive (false);
			button5.SetActive (false);
			button6.SetActive (true);
			button7.SetActive (true);
			button8.SetActive (true);
		}
		if(Input.GetMouseButtonDown(0) && this.tag == "button5") {
			MenuDirector.GetComponent<MenuDirector>().rule = 2;
			bilmenu1.SetActive (false);
			button4.SetActive (false);
			button5.SetActive (false);
			button6.SetActive (true);
			button7.SetActive (true);
			button8.SetActive (true);
		}
		if(Input.GetMouseButtonDown(0) && this.tag == "button6") {
			MenuDirector.GetComponent<MenuDirector>().level = 1;
			MenuDirector.GetComponent<MenuDirector> ().Confirm ();
			SceneManager.LoadScene ("GameScene");
		}
		if(Input.GetMouseButtonDown(0) && this.tag == "button7") {
			MenuDirector.GetComponent<MenuDirector>().level = 2;
			MenuDirector.GetComponent<MenuDirector> ().Confirm ();
			SceneManager.LoadScene ("GameScene");
		}
		if(Input.GetMouseButtonDown(0) && this.tag == "button8") {
			MenuDirector.GetComponent<MenuDirector>().level = 3;
			MenuDirector.GetComponent<MenuDirector> ().Confirm ();
			SceneManager.LoadScene ("GameScene");
		}
		if(Input.GetMouseButtonDown(0) && this.tag == "backbutton1") {
			bilmenu1.SetActive (true);
			button4.SetActive (true);
			button5.SetActive (true);
			button6.SetActive (false);
			button7.SetActive (false);
			button8.SetActive (false);
		}
	}
}
