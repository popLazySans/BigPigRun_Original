using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Tutorial : MonoBehaviour {

	public GameObject t1;
	public GameObject t2;
	public GameObject t3;
	public GameObject t4;
	public GameObject t5;
	public GameObject t6;
	public GameObject t7;
	public GameObject t8;
	public GameObject t9;
	public GameObject t10;
	public GameObject t11;
	public  int scene;
	public int loc;
	// Use this for initialization
	void Start () {
		PlayerPrefs.DeleteKey ("Scene");
		Time.timeScale= 0;

	}
	
	// Update is called once per frame
	void Update () {
		scene = PlayerPrefs.GetInt ("Scene", 0);
		if (PlayerSuvive.twothor == 1) {
			PlayerPrefs.SetInt ("Scene", 7);
			PlayerSuvive.twothor = 0;
		}
		if (PlayerSuvive.twothor == 2) {
			PlayerPrefs.SetInt ("Scene", 11);
			PlayerSuvive.twothor = 0;
		}
		if (PlayerSuvive.twothor == 3) {
			PlayerPrefs.SetInt ("Scene", 12);
			PlayerSuvive.twothor = 0;
		}
		if (scene == 5 && loc == 1) {
			t6.SetActive (false);
			t7.SetActive (true);
			StartCoroutine (threeSec ());
			loc = 0;
		}
		if (scene == 6) {
			t7.SetActive (false);
		}
		if (scene == 7 && loc == 0) {
			t8.SetActive (true);
			StartCoroutine (threeSec ());
			loc = 1;
		}
		if (scene == 8 && loc ==1) {
			t8.SetActive (false);
			StartCoroutine (threeSec ());
			loc = 0;
		}
		if(scene == 9 && loc == 0){
			t9.SetActive (true);
			StartCoroutine (threeSec ());
			loc = 1;
		}
		if (scene == 10) 
		{
			t9.SetActive (false);
		}
		if (scene == 11) {
			Time.timeScale = 0;
			t10.SetActive (true);
		}
		if (scene == 12) {
			t10.SetActive (false);
			t11.SetActive (true);

		}
		if (scene == 13) {
			PlayerSuvive.sc = 1;
			Time.timeScale = 1;
			SceneManager.LoadScene ("SpherePlay1");
		}
	}
	public void yes() {
		t1.SetActive (false);
		t2.SetActive (true);
		PlayerPrefs.SetInt ("Scene", 1);
	}
	public void talk(){
		if (scene == 1) 
		{
			t2.SetActive (false);
			t3.SetActive (true);
		}
		if (scene == 2) {
			t3.SetActive (false);
			t4.SetActive (true);
		}
		if (scene == 3) {
			t4.SetActive (false);
			t5.SetActive (true);
		}
		if (scene == 4 && loc == 0) {
			t5.SetActive (false);
			t6.SetActive (true);
			Time.timeScale = 1;
			loc = 1;
			StartCoroutine (threeSec ());
		}
		if (scene == 12) {
			PlayerPrefs.SetInt ("Scene", scene + 1);
		}
		if (scene > 0 && scene < 4) {
			PlayerPrefs.SetInt("Scene",scene+1);
		}

	}
	IEnumerator threeSec(){
		yield return new WaitForSeconds (4);
		PlayerPrefs.SetInt ("Scene", scene + 1);
	}
}
