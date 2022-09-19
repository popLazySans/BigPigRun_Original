using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SanA : MonoBehaviour {
	
	private float tran;
	private float pro;
	private float vit;
	private float carbo;
	public Slider trbar;
	public Slider Pbar;
	public Slider Cbar;
	public Slider Vbar;
	public float mT;
	public float mP;
	public float mV;
	public float mC;
	public KeyCode jump;
	public static float lockPoint;
	
	// Update is called once per frame
	void Update () 
	{
		NumTran();
		NumPro();
		NumCarbo();
		Nutrial();
		NuttialBar();
		Life();
		Ultimate();
	}

	public void NumTran() 
	{
		mT = Point.point_origin * 0.3f;
	}
	public void NumPro()
	{
		mP = PlayerPrefs.GetFloat("Weight", 0) * 8;
	}
	public void NumCarbo()
	{
		mC = (Point.point_origin - mT) - mP;
	}
	public void Nutrial()
	{
		tran = Point.Tranfat_value;
		pro = Point.Protein_value;
		vit = Point.Vitamin_value;
		carbo = Point.Carbo_value;
	}
	public void NuttialBar() 
	{
		trbar.value = tran;
		Pbar.value = pro;
		Vbar.value = vit;
		Cbar.value = carbo;
		Pbar.maxValue = mP;
		trbar.maxValue = mT;
		Cbar.maxValue = mC;
	}
	public void Life() 
	{
		if (tran > mT && pro > mP && carbo > mC)
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
		if (vit >= 100 && Input.GetKeyDown(jump))
		{
			Point.Tranfat_value = 0;
			Point.Protein_value = 0;
			Point.Carbo_value = 0;
			Point.Vitamin_value = 0;
			lockPoint = 1;
		}
	}
}
