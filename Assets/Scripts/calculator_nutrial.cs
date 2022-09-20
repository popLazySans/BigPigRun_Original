using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class calculator_nutrial : MonoBehaviour
{
    private SanA san_a;
    

    // Start is called before the first frame update
    void Start()
    {
        san_a = GetComponent<SanA>();
    }

    // Update is called once per frame
    void Update()
    {
        NuttialBar();
        NumberCarbohydrate();
        NumberProtein();
        NumberTransFat();
    }
    public void NumberTransFat()
    {
        san_a.CalculateTransFat = Point.point_origin * 0.3f;
    }
    public void NumberProtein()
    {
        san_a.CalculateProtein = PlayerPrefs.GetFloat("Weight", 0) * 8;
    }
    public void NumberCarbohydrate()
    {
        san_a.CalculateCarbohydrate 
            = (Point.point_origin - san_a.CalculateTransFat) - san_a.CalculateProtein;
    }

    public void NuttialBar()
    {
        san_a.TransFatBar.value = san_a.Transfat;
        san_a.ProteinBar.value = san_a.Protein;
        san_a.VitaminBar.value = san_a.Vitamin;
        san_a.CarbohydrateBar.value = san_a.Carbohydrate;
        san_a.ProteinBar.maxValue = san_a.CalculateProtein;
        san_a.TransFatBar.maxValue = san_a.CalculateTransFat;
        san_a.CarbohydrateBar.maxValue = san_a.CalculateCarbohydrate;
    }
}
