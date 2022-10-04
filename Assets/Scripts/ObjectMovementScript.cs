﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovementScript : MonoBehaviour {
	public int point;
	public int lk = 0;
	// Use this for initialization
	public float speed;
	private Vector3 moveDirection;
	// Update is called once per frame
	void Update () {
		if (IsSpeedChange(4, 0)) 
		{
			speed += 1; 
			lk = 1;
			}
		if (IsSpeedChange(4, 1)) 
		{
			speed += 0.0005f; 
			lk = 1;
		}
		if (speed >= 8) 
		{
			lk = 2;
		}
		moveDirection = new Vector3(0, 0,-speed).normalized;
	}
	void FixedUpdate()
	{
		GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
	}

	bool IsSpeedChange(int currentScene,int lkValue)
	{
		return SceneLevelManager.currentScene >= currentScene && lk == lkValue;
	}


}
