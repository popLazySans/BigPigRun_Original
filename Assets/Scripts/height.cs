using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class height : Set_Appearance<int>
{
    public int value;
    protected override int SetGen()
    {
        data = PlayerPrefs.GetInt("Height", 0);
        return data;
    }
    void Start()
    {
        value = SetGen();
    }
}
