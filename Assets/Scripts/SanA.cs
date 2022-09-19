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
		mT = PlayerSuvive.point_origin * 0.3f;
	}
	public void NumPro()
	{
		mP = PlayerPrefs.GetFloat("Weight", 0) * 8;
	}
	public void NumCarbo()
	{
		mC = (PlayerSuvive.point_origin - mT) - mP;
	}
	public void Nutrial()
	{
		tran = PlayerSuvive.Tranfat_value;
		pro = PlayerSuvive.Protein_value;
		vit = PlayerSuvive.Vitamin_value;
		carbo = PlayerSuvive.Carbo_value;
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
			PlayerSuvive.TranfatCheck = 1;
		}
		else
		{
			PlayerSuvive.TranfatCheck = 0;
		}
	}
	public void Ultimate() 
	{
		if (vit >= 100 && Input.GetKeyDown(jump))
		{
			PlayerSuvive.Tranfat_value = 0;
			PlayerSuvive.Protein_value = 0;
			PlayerSuvive.Carbo_value = 0;
			PlayerSuvive.Vitamin_value = 0;
			lockPoint = 1;
		}
	}
}
