using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SanA : MonoBehaviour {
	
	public float Transfat;
	public float Protein;
	public float Vitamin;
	public float Carbohydrate;
	public Slider TransFatBar;
	public Slider ProteinBar;
	public Slider CarbohydrateBar;
	public Slider VitaminBar;
	public float CalculateTransFat;
	public float CalculateProtein;
	public float CalculateVitamin;
	public float CalculateCarbohydrate;
	public KeyCode jump;
	private calculator_nutrial caculator_n;
	public static float lockPoint;
	
	// Update is called once per frame
	void Update () 
	{
		
		Nutrial();
		Life();
		Ultimate();
	}


	
	public void Nutrial()
	{
		Transfat = Point.Tranfat_value;
		Protein = Point.Protein_value;
		Vitamin = Point.Vitamin_value;
		Carbohydrate = Point.Carbo_value;
	}
	
	public void Life() 
	{
		if (Transfat > CalculateTransFat && Protein > CalculateProtein && Carbohydrate > CalculateCarbohydrate)
		{
			Point.tranfat_check = 1;
		}
		else
		{
			Point.tranfat_check = 0;
		}
	}
	public void Ultimate() 
	{
		if (Vitamin >= 100 && Input.GetKeyDown(jump))
		{
			Point.Tranfat_value = 0;
			Point.Protein_value = 0;
			Point.Carbo_value = 0;
			Point.Vitamin_value = 0;
			lockPoint = 1;
		}
	}
}
