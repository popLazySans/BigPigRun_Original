using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Info : MonoBehaviour {
	public InputField h;
	public InputField w;
	public InputField n;
	public InputField a;
	private float valueH;
	private float valueW;
	private string valueN;
	private int valueA;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
	public void gentleMen(){
		SceneManager.LoadScene("Height");
		PlayerPrefs.SetInt ("Gender", 1);
	}
	public void Lady(){
		SceneManager.LoadScene("Height");
		PlayerPrefs.SetInt ("Gender", 2);
	}
	public void Height(){
		SceneManager.LoadScene ("Weight");
		valueH = float.Parse(h.text);
		PlayerPrefs.SetFloat ("Height", valueH);
		//Debug.Log (valueH);
	}
	public void Weight(){
		SceneManager.LoadScene ("Age");
		valueW = float.Parse (w.text);
		PlayerPrefs.SetFloat ("Weight", valueW);
	}
	public void Age(){
		SceneManager.LoadScene ("Thank");
		valueA = int.Parse (a.text);
		PlayerPrefs.SetInt ("Age", valueA);
	}
	public void ThankYou(){
		SceneManager.LoadScene ("main");
		valueN = n.text;
		PlayerPrefs.SetString ("Name", valueN);
	}
}
