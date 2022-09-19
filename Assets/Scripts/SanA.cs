using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SanA : MonoBehaviour {
	
	private float Transfat;
	private float Protein;
	private float Vitamin;
	private float Carbohydrate;
	public Slider TransFatBar;
	public Slider ProteinBar;
	public Slider CarbohydrateBar;
	public Slider VitaminBar;
	public float CalculateTransFat;
	public float CalculateProtein;
	public float CalculateVitamin;
	public float CalculateCarbohydrate;
	public KeyCode jump;
	public static float lockPoint;
	
	// Update is called once per frame
	void Update () 
	{
		NumberTransFat();
		NumberProtein();
		NumberCarbohydrate();
		Nutrial();
		NuttialBar();
		Life();
		Ultimate();
	}

	public void NumberTransFat() 
	{
		CalculateTransFat = PlayerSuvive.poL * 0.3f;
	}
	public void NumberProtein()
	{
		CalculateProtein = PlayerPrefs.GetFloat("Weight", 0) * 8;
	}
	public void NumberCarbohydrate()
	{
		CalculateCarbohydrate = (PlayerSuvive.poL - CalculateTransFat) - CalculateProtein;
	}
	public void Nutrial()
	{
		Transfat = PlayerSuvive.trans;
		Protein = PlayerSuvive.protein;
		Vitamin = PlayerSuvive.vin;
		Carbohydrate = PlayerSuvive.car;
	}
	public void NuttialBar() 
	{
		TransFatBar.value = Transfat;
		ProteinBar.value = Protein;
		VitaminBar.value = Vitamin;
		CarbohydrateBar.value = Carbohydrate;
		ProteinBar.maxValue = CalculateProtein;
		TransFatBar.maxValue = CalculateTransFat;
		CarbohydrateBar.maxValue = CalculateCarbohydrate;
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
