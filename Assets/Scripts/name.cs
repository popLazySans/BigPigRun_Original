using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class name : Set_Appearance<string>
{
    public string value;
    protected override string SetGen()
    {
        data = PlayerPrefs.GetString("Name", "");
        return data;
    }
    void Start()
    {
        value = SetGen();
    }
}
