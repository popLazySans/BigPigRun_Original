using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class age : Set_Appearance<int>
{
    public int value;
    protected override int SetGen()
    {
        data = PlayerPrefs.GetInt("Age", 0);
        return data;
    }
    void Start()
    {
        value = SetGen();
    }
}
