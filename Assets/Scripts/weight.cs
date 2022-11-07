using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weight : Set_Appearance<int>
{
	public int value;
	protected override int SetGen()
	{
		data = PlayerPrefs.GetInt("weight", 0);
		return data;
	}
    void Start()
    {
		value = SetGen();
    }
}
