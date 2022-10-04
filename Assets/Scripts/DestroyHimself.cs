using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHimself : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (destroyObjectRoutine ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator destroyObjectRoutine(){
		yield return new WaitForSeconds (15);
		Destroy (this.gameObject);
	}
}
