using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gender : Set_Appearance<int>
{
    public int value;
    protected override int SetGen()
    {
        data = PlayerPrefs.GetInt("Gender", 0);
        return data;
    }
    void Start()
    {
        value = SetGen();
    }
}
