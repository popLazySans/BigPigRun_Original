using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMovementScript : MonoBehaviour {

	public float speed;
	public GameObject pig;
	public float spd;
	public GameObject mv;
	// Use this for initialization
	// Update is called once per frame
	void Update () {
		mv.transform.Rotate (-speed, 0, 0);
	}
}
