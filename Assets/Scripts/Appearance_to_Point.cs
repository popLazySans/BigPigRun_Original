using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appearance_to_Point : MonoBehaviour
{
	private gender gender;
	private age age;
	private height height;
	private weight weight;
	private name name;
	private Point point;

	public bool fixUpdateBug = false;
    // Start is called before the first frame update
    void Start()
    {
		gender = GetComponent<gender>();
		age = GetComponent<age>();
		height = GetComponent<height>();
		weight = GetComponent<weight>();
		name = GetComponent<name>();
		point = GetComponent<Point>();
		
		/*Debug.Log("gen "+gender.value);
		Debug.Log("age "+age.value);
		Debug.Log("height "+ height.value);
		Debug.Log("weight"+ weight.value);
		Debug.Log("name "+name.value);*/
	}

    // Update is called once per frame
    void Update()
    {
        if (fixUpdateBug == false)
        {
			checkGender();
			fixUpdateBug = true;
		}
	}
	public void checkGender()
	{
		if (gender.value == 1) { Man_Calculator(); }
		if (gender.value == 2) { Woman_Calculator(); }
	}
	public void Man_Calculator()
	{
		point.point_current = ((10f * height.value) + (6.25f * weight.value) - (5f * age.value) + 5f) * 1.2f;
		Debug.Log("calculated man!!!");
	}
	public void Woman_Calculator()
	{
		point.point_current = ((10f * height.value) + (6.25f * weight.value) - (5f * age.value) - 161f) * 1.2f;
		Debug.Log("calculated woman!!!");
	}
}
