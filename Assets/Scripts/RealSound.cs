using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class RealSound : MonoBehaviour {

	public AudioMixer audioMixer;
	public static float valueS;
	Resolution[] resolutions;
	void Start()
	{
		resolutions = Screen.resolutions;


		List<string> options = new List<string> ();

		int currentResolutionIndex = 0;
		for (int i = 0; i < resolutions.Length; i++) 
		{
			string option = resolutions [i].width + "x" + resolutions [i].height;
			options.Add (option);

			if (resolutions [i].width == Screen.currentResolution.width && 
				resolutions[i].height == Screen.currentResolution.height) 
			{
				currentResolutionIndex = i;
			}
		}
			
	}
	public void SetVolume(float volume)
	{
		audioMixer.SetFloat ("volume",volume);
		DontDestroyOnLoad (this.audioMixer);
		valueS = volume;
		volume = valueS;
	}
		

	public void SetFullscreen (bool isFullscreen)
	{
		Screen.fullScreen = isFullscreen;
	}
}
