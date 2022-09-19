using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point_UI : MonoBehaviour
{
    public Text minimum_calories_text;
    public Text maximum_calories_text;
    public Point pointManager;
    public Slider Calories_slide;
    public static float point_toStatic;
    // Start is called before the first frame update
    void Start()
    {
        pointManager = GetComponent<Point>();
        SetCalText();
        SetCalBar();
    }

    // Update is called once per frame
    void Update()
    {
        SetUI();
    }
    public void SetUI()
    {
        SetCalText();
        SetCalBar();
        SetValueToPoint();
    }
    public void SetCalText()
    {
        minimum_calories_text.text = "Low Cal :" + pointManager.point_minimum.ToString();
        maximum_calories_text.text = "High Cal :" + pointManager.point_maximum.ToString();
    }
    public void SetCalBar()
    {
        Calories_slide.minValue = pointManager.point_minimum;
        Calories_slide.maxValue = pointManager.point_maximum;
    }
    public void SetValueToPoint()
    {
        Calories_slide.value =pointManager.point_current;
        point_toStatic = pointManager.point_current;
        PlayerMovementScript.pot = pointManager.point_current;
    }
}
