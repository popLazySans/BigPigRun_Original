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
	private int valueH;
	private int valueW;
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
		valueH = int.Parse(h.text);
		PlayerPrefs.SetInt ("Height", valueH);
		//Debug.Log (valueH);
	}
	public void Weight(){
		SceneManager.LoadScene ("Age");
		valueW = int.Parse (w.text);
		PlayerPrefs.SetInt ("weight", valueW);
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
