using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Set_Appearance<T> : MonoBehaviour
{
	public T data;
	/*public int gender;
    public int age;
    public string name;
    public float height;
    public float weight;

	
    void Start()
    {
        SetAppearance();
    }

    void Update()
    {
        
    }
    public void SetAppearance()
    {
        gender = SetGender();
        age = SetAge();
        height = SetHeight();
        weight = SetWeight();
        name = SetName();
    }
	public int SetGender()
	{
		int gender = PlayerPrefs.GetInt("Gender", 0);
		return gender;
	}
	public int SetAge()
	{
		int age = PlayerPrefs.GetInt("Age", 0);
		return age;
	}
	public float SetHeight()
	{
		float height = PlayerPrefs.GetFloat("Height", 0);
		return height;
	}
	public float SetWeight()
	{
		float weight = PlayerPrefs.GetFloat("weight", 0);
		return weight;
	}
	public string SetName()
	{
		string name = PlayerPrefs.GetString("Name", "");
		return name;
	}*/
	protected virtual T SetGen()
    {
		return data;
    }
}
