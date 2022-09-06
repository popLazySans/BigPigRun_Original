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
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		NumTran();
		NumPro();
		NumCarbo();
		Nutrial();
		trbar.value = tran;
		Pbar.value = pro;
		Vbar.value = vit;
		Cbar.value = carbo;
		Pbar.maxValue = mP;
		trbar.maxValue = mT;
		Cbar.maxValue = mC;
		if (tran > mT && pro > mP && carbo > mC) {
			PlayerSuvive.sanCheck = 1;
		} else {
			PlayerSuvive.sanCheck = 0;
		}
		if (vit >= 100 && Input.GetKeyDown(jump)) {
			PlayerSuvive.trans = 0;
			PlayerSuvive.protein = 0;
			PlayerSuvive.car = 0;
			PlayerSuvive.vin = 0;
			lockPoint = 1;
		}
	}

	public void NumTran() 
	{
		mT = PlayerSuvive.poL * 0.3f;
	}
	public void NumPro()
	{
		mP = PlayerPrefs.GetFloat("Weight", 0) * 8;
	}
	public void NumCarbo()
	{
		mC = (PlayerSuvive.poL - mT) - mP;
	}
	public void Nutrial()
	{
		tran = PlayerSuvive.trans;
		pro = PlayerSuvive.protein;
		vit = PlayerSuvive.vin;
		carbo = PlayerSuvive.car;
	}
}
