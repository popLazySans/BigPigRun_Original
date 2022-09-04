using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StopButton : MonoBehaviour {
	public bool pause;
	public GameObject tex ;
	public int logTime;
	public GameObject hide;
	// Use this for initialization
	void Start () {
		tex.GetComponent<Text>().text ="Pause";
		pause = false;
		tex.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			pause = !pause;
		}
		if (pause) {
			hide.SetActive (true);
			tex.SetActive (true);
			Time.timeScale = 0;
			logTime = 1;
		} else if (!pause && logTime == 1) {
			//StartCoroutine (timeLoss);
			Time.timeScale = 1;
			logTime = 0;
			hide.SetActive (false);
			tex.SetActive (false);
		}
	}
	public void stop()
	{
		pause = !pause;
		if (pause) {
			Time.timeScale = 0;
			tex.SetActive (true);
		} else if (!pause) {
			//StartCoroutine (timeLoss);
			tex.SetActive (false);
			Time.timeScale = 1;
		}
	}
	/*IEnumerator timeLoss (){
		yield return new WaitForSeconds (3f);
	}*/
}
