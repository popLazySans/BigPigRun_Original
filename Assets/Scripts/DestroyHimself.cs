using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHimself : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (destroy ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator destroy(){
		yield return new WaitForSeconds (15);
		Destroy (this.gameObject);
	}
}
