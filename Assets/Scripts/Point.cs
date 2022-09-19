using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public float point_current;
    public static float point_origin;
    public float point_maximum;
    public float point_minimum;
    public int current_amout_burn;
    public float current_weight_decrease;
    // Start is called before the first frame update
    void Start()
    {
        SetCal();
    }

    // Update is called once per frame
    void Update()
    {
        SettingValue();
    }
    public void SetCal()
    {
        point_origin = point_current;
        SetLowandHightCal();
        SetCalText();
        SetCalBar();
    }
    public void SetLowandHightCal()
    {
        point_maximum = point_current + 250;
        point_minimum = point_current - 250;
    }
    public void SettingValue()
    {
        current_weight_decrease = current_amout_burn / 7700f;
        HightScore_Current();
        SetValueToPoint();
        Set_Nutrients_text();
    }
    public void count_calculate()
    {
        score_point += 0.014f;
        current_amout_burn += 1;
        point_current -= 1f;
    }
}
