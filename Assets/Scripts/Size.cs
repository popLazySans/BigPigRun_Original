using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Size : MonoBehaviour {

	public float size;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		size = PlayerSuvive.point_toStatic / 1000;
		transform.localScale = new Vector3 ((3f/20f) + size/15 ,(3f/20f) + size/15 ,(3f/20f) + size/15 );
	}
}
