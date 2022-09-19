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
    public Text highScore;
    public GameObject Green_weighter;
    public GameObject Red_weighter;
    public Text itemName;
    public Text itemProtein;
    public Text itemCarbohydrate;
    public Text itemTranfat;
    public Text itemVitamin;

    public GameObject hamburger_picture;
    public GameObject chicken_picture;
    public GameObject pineapple_picture;
    public GameObject vegetable_picture;
    public GameObject rice_picture;
    public GameObject watermelon_picture;
    public GameObject mushroom_picture;
    public GameObject food_detail_panel;

    public GameObject Score_panel;
    public GameObject Burn_amout_panel;
    public GameObject Weight_decreased_panel;

    public Text protein_text;
    public Text carbohydrate_text;
    public Text vintamin_text;
    public Text tranfat_text;
    public GameObject Point_panel;


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
        SetCalUI();
        SetValueToPoint();
        SetHighScore();
        ChangeColor_Weighter();
        Set_Nutrients_text();
    }
    public void SetCalUI()
    {
        SetCalText();
        SetCalBar();
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
    public void SetHighScore()
    {
        highScore.text = "Best Score " + PlayerPrefs.GetFloat("HighScore1", 0).ToString() + " km";
    }
    public void ChangeColor_Weighter()
    {
        if (pointManager.point_maximum >= pointManager.point_current && pointManager.point_minimum <= pointManager.point_current) { green_weight(); }
        else { red_weight(); }
    }
    public void green_weight()
    {
        Green_weighter.SetActive(true);
        Red_weighter.SetActive(false);
    }
    public void red_weight()
    {
        Green_weighter.SetActive(false);
        Red_weighter.SetActive(true);
    }
    public void Item_text_Disable()
    {
        itemName.text = "";
        itemProtein.text = "";
        itemCarbohydrate.text = "";
        itemTranfat.text = "";
        itemVitamin.text = "";
    }
    public void Set_item_object()
    {
        food_detail_panel.SetActive(false);
        hamburger_picture.SetActive(false); chicken_picture.SetActive(false); pineapple_picture.SetActive(false); vegetable_picture.SetActive(false); rice_picture.SetActive(false); watermelon_picture.SetActive(false); mushroom_picture.SetActive(false);
    }
    public void Summary_text()
    {
        Score_panel.GetComponent<Text>().text = "You get score " + Point.score_point.ToString() + " km";
        Burn_amout_panel.GetComponent<Text>().text = "Total amount of burns is " + pointManager.current_amout_burn.ToString() + " kcal";
        Weight_decreased_panel.GetComponent<Text>().text = "Total weight decreased " + pointManager.current_weight_decrease.ToString() + " kg";
    }
    public void Set_Nutrients_text()
    {
        protein_text.text = "Protein " + Point.Protein_value.ToString() + " kCal";
        carbohydrate_text.text = "Carbohydrate " + Point.Carbo_value.ToString() + " kCal";
        vintamin_text.text = "Vitamin " + Point.Vitamin_value.ToString() + " kCal";
        tranfat_text.text = "Fat " + Point.Tranfat_value.ToString() + " kCal";
        Point_panel.GetComponent<Text>().text = pointManager.point_current.ToString() + " kCal";
    }
}
