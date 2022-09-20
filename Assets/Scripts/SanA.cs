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
		Transfat = PlayerSuvive.trans;
		Protein = PlayerSuvive.protein;
		Vitamin = PlayerSuvive.vin;
		Carbohydrate = PlayerSuvive.car;
	}
	
	public void Life() 
	{
		if (Transfat > CalculateTransFat && Protein > CalculateProtein && Carbohydrate > CalculateCarbohydrate)
		{
			PlayerSuvive.sanCheck = 1;
		}
		else
		{
			PlayerSuvive.sanCheck = 0;
		}
	}
	public void Ultimate() 
	{
		if (Vitamin >= 100 && Input.GetKeyDown(jump))
		{
			PlayerSuvive.trans = 0;
			PlayerSuvive.protein = 0;
			PlayerSuvive.car = 0;
			PlayerSuvive.vin = 0;
			lockPoint = 1;
		}
	}
}
