using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class onSound : MonoBehaviour {

	public GameObject sound; 
	public int off;
	private static onSound instance = null;
	public static onSound Instance
	// Use this for initialization
	{
	get { return instance; }
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		off = Link.off;
		if (off == 0) {
			sound.SetActive (true);
		}

	}
	void Awake()
	{
		if (instance != null && instance != this)
		{
			Destroy(this.gameObject);
			return;
		}
		else
		{
			instance = this;
		}
		DontDestroyOnLoad (this.gameObject);
	}
}
