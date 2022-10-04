using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StopButton : MonoBehaviour {
	public bool IsPause;
	public GameObject tex ;
	public int logTime;
	public GameObject hide;
	// Use this for initialization
	void Start () {
		tex.GetComponent<Text>().text ="Pause";
		IsPause = false;
		tex.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			IsPause = !IsPause;
		}
		if (IsPause) {
			hide.SetActive (true);
			tex.SetActive (true);
			Time.timeScale = 0;
			logTime = 1;
		} else if (IsResume()) {
			
			Time.timeScale = 1;
			logTime = 0;
			hide.SetActive (false);
			tex.SetActive (false);
		}
	}

	bool IsResume()
	{
		return !IsPause && logTime == 1;
	}

	public void stop()
	{
		IsPause = !IsPause;
		if (IsPause) {
			Time.timeScale = 0;
			tex.SetActive (true);
		} else if (!IsPause) {
			
			tex.SetActive (false);
			Time.timeScale = 1;
		}
	}

}
