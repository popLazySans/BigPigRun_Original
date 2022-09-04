using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SoundSpeaker : MonoBehaviour {

	public GameObject speak;
	public GameObject donSpeak;
	public float value;
	public AudioMixer audioMixer;
	public GameObject hi;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		value = RealSound.valueS;
	}
	public void Speaker(){
		speak.SetActive (false);
		donSpeak.SetActive (true);
		audioMixer.SetFloat ("volume", RealSound.valueS -100);
		hi.SetActive (false);
	}
	public void DonSpeaker()
	{
		speak.SetActive (true);
		donSpeak.SetActive (false);
		audioMixer.SetFloat ("volume", RealSound.valueS);
		hi.SetActive (true);
	}
}
