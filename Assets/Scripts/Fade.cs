using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour {

	public Text point;
	// Use this for initialization
	void Start () {
		point = GetComponent<Text> ();
		point.transform.Translate (0,Time.deltaTime,0);
		StartCoroutine (FadeOutRoutine ());
	}
	
	IEnumerator FadeOutRoutine()
	{
		for (float f =1f; f >= -0.05f; f -= 0.05f) {
			yield return new WaitForSeconds (0.05f);

		}
	}
}
