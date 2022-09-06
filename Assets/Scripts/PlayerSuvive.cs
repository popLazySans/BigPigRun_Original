using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerSuvive : MonoBehaviour {
	public GameObject item;
	public float point;
	public float pointP;
	public float pointD;
	public static float time;
	public int time2;
	public float down;
	public GameObject show;
	public GameObject pS;
	public static float trans;
	public static float protein;
	public static float car;
	public static float vin;
	public static float pon;
	public static float poL;
	public int Dc = 0;
	public GameObject iM1;
	public GameObject iM2;
	public GameObject antiP;
	public GameObject tex;
	public GameObject tex2;
	public GameObject tex3;
	public Text highScore;
	public GameObject hide;
	public GameObject mushD;
	public GameObject hungry;
	public GameObject fatty;
	public GameObject docty;
	public GameObject anDoc;
	public Slider bar;
	public GameObject itemI1;
	public GameObject itemI2;
	public GameObject itemI3;
	public GameObject itemI4;
	public GameObject itemI5;
	public GameObject itemI6;
	public GameObject itemI7;
	public Text itemN;
	public Text itemP;
	public Text itemC;
	public Text itemO;
	public Text itemV;
	public float one = 0.01f;
	public float height;
	public float weight;
	public int gen;
	public int age;
	public string name;
	public Text low;
	public Text high;
	public static int sanCheck;
	public static int twothor;
	public Text proBar;
	public Text carBar;
	public Text vinBar;
	public Text oilBar;
	public GameObject black;
	public int sCoreLock1;
	public int sCoreLock2;
	public int sCoreLock3;
	public int sCoreLock4;
	public int sCoreLock5;

	public static int sc = 1;
	void Start() {
		StartCoroutine(count());
		SetHighScore();
		SetAppearance();
		checkGender();
		SetCal();
	}
	public void SetHighScore()
	{
		highScore.text = "Best Score " + PlayerPrefs.GetFloat("HighScore1", 0).ToString() + " km";
	}
	public void SetAppearance()
	{
		gen = SetGender();
		age = SetAge();
		height = SetHeight();
		weight = SetWeight();
		name = SetName();
	}
	public int SetGender()
	{
		int gender = PlayerPrefs.GetInt("Gender", 0);
		return gender;
	}
	public int SetAge()
	{
		int age = PlayerPrefs.GetInt("Age", 0);
		return age;
	}
	public float SetHeight()
	{
		float height = PlayerPrefs.GetFloat("Height", 0);
		return height;
	}
	public float SetWeight()
	{
		float weight = PlayerPrefs.GetFloat("weight", 0);
		return weight;
	}
	public string SetName()
	{
		string name = PlayerPrefs.GetString("Name", "");
		return name;
	}
	public void checkGender()
	{
		if (gen == 1) { Man_Calculator(); }
		if (gen == 2) { Woman_Calculator(); }
	}
	public void Man_Calculator()
	{
		point = ((10f * height) + (6.25f * weight) - (5f * age) + 5f) * 1.2f;
	}
	public void Woman_Calculator()
	{
		point = ((10f * height) + (6.25f * weight) - (5f * age) - 161f) * 1.2f;
	}
	public void SetCal()
	{
		poL = point;
		SetLowandHightCal();
		SetCalText();
		SetCalBar();
	}
	public void SetLowandHightCal()
	{
		pointP = point + 250;
		pointD = point - 250;
	}
	public void SetCalText()
	{
		low.text = "Low Cal :" + pointD.ToString();
		high.text = "High Cal :" + pointP.ToString();
	}
	public void SetCalBar()
	{
		bar.minValue = pointD;
		bar.maxValue = pointP;
	}

	void Update() {
		SettingValue();
		ChangeColor_Weighter();
		Die_Statement();
		Ultimate();
	}
	public void SettingValue()
	{
		down = time2 / 7700f;
		HightScore_Current();
		SetValueToPoint();
		Set_Nutrients_text();
	}
	public void SetValueToPoint()
	{
		bar.value = point;
		pon = point;
		PlayerMovementScript.pot = point;
	}
	public void HightScore_Current()
	{
		Rank_Checker("HighScore5", "Namest5", "HighScore4", "Namest4", "HighScore3", "Namest3", "HighScore2", "Namest2", "HighScore1", "Namest1", sCoreLock5, sCoreLock4, sCoreLock3, sCoreLock2, sCoreLock1);
	}
	public void Rank_Checker(string rankScore5, string rankName5, string rankScore4, string rankName4, string rankScore3, string rankName3, string rankScore2, string rankName2, string rankScore1, string rankName1, int scoreLock5, int scoreLock4, int scoreLock3, int scoreLock2, int scoreLock1)
	{
		if (time > PlayerPrefs.GetFloat(rankScore5, 0)) { Update_Ranking(rankScore4, rankName4, rankScore5, rankName5, "", "", scoreLock5);
			if (time > PlayerPrefs.GetFloat(rankScore4, 0)) { Update_Ranking(rankScore3, rankName3, rankScore4, rankName4, rankScore5, rankName5, scoreLock4);
				if (time > PlayerPrefs.GetFloat(rankScore3, 0)) { Update_Ranking(rankScore2, rankName2, rankScore3, rankName3, rankScore4, rankName4, scoreLock3);
					if (time > PlayerPrefs.GetFloat(rankScore2, 0)) { Update_Ranking(rankScore1, rankName1, rankScore2, rankName2, rankScore3, rankName3, scoreLock2);
						if (time > PlayerPrefs.GetFloat(rankScore1, 0)) { Update_Ranking("", "", rankScore1, rankName1, rankScore2, rankName2, scoreLock1); } } } }}
	}
	public void Update_Ranking(string rankScorePlus, string rankNamePlus, string rankScore, string rankName, string rankScoreDe, string rankNameDe, int scoreLock)
	{
		if (scoreLock == 0) { if (rankScoreDe != "") { reset_HighScore(rankScoreDe, rankNameDe, rankScore, rankName); } scoreLock = 1; }
		if (rankScorePlus == "" || (time > PlayerPrefs.GetFloat(rankScore, 0) && time < PlayerPrefs.GetFloat(rankScorePlus, 0))) { set_HighScore(rankScore, rankName); }
	}
	public void reset_HighScore(string rankScoreDe, string rankNameDe, string rankScore, string rankName)
	{
		PlayerPrefs.SetFloat(rankScoreDe, PlayerPrefs.GetFloat(rankScore, 0));
		PlayerPrefs.SetString(rankNameDe, PlayerPrefs.GetString(rankName, ""));
	}
	public void set_HighScore(string rankScore, string rankName)
	{
		PlayerPrefs.SetFloat(rankScore, time);
		PlayerPrefs.SetString(rankName, name);
	}
	public void ChangeColor_Weighter()
	{
		if (pointP >= point && pointD <= point) { green_weight(); }
		else { red_weight(); }
	}
	public void green_weight()
	{
		iM1.SetActive(true);
		iM2.SetActive(false);
	}
	public void red_weight()
	{
		iM1.SetActive(false);
		iM2.SetActive(true);
	}
	public void Die_Statement()
	{
		Hungry();
		Fatty();
		Doctor_Denied();
	}
	public void Hungry()
	{
		if (point <= 0)
		{ hungry.SetActive(true);
			hide.SetActive(true);
			show_died_text(); }
	}
	public void Fatty()
	{
		if (sanCheck == 1)
		{ hide.SetActive(true);
			fatty.SetActive(true);
			show_died_text();
			Time.timeScale = 0; }
	}
	public void Doctor_Denied()
	{
		if (AutoObjectSpawnerLock.die == 1)
		{
			StartCoroutine(countFive());
		}
	}
	IEnumerator countFive()
	{
		yield return new WaitForSeconds(15);
		if (AutoObjectSpawnerLock.die == 1)
		{hide.SetActive(true);
		anDoc.SetActive(true);
		show_died_text();}
	}
	public void show_died_text()
	{
		Summary_text();
		antiP.SetActive(false);
		Time.timeScale = 0;
		Item_text();
		Set_item_object();
	}
	public void Summary_text()
	{
		tex.GetComponent<Text>().text = "You get score " + time.ToString() + " km";
		tex2.GetComponent<Text>().text = "Total amount of burns is " + time2.ToString() + " kcal";
		tex3.GetComponent<Text>().text = "Total weight decreased " + down.ToString() + " kg";
	}
	public void Item_text ()
	{
		itemN.text = "";
		itemP.text = "";
		itemC.text = "";
		itemO.text = "";
		itemV.text = "";
	}
	public void Set_item_object()
    {
		black.SetActive(false);
		itemI1.SetActive(false);itemI2.SetActive(false);itemI3.SetActive(false);itemI4.SetActive(false);itemI5.SetActive(false);itemI6.SetActive(false);itemI7.SetActive(false);
	}
	
	public void Set_Nutrients_text()
    {
		proBar.text = "Protein " + protein.ToString() + " kCal";
		carBar.text = "Carbohydrate " + car.ToString() + " kCal";
		vinBar.text = "Vitamin " + vin.ToString() + " kCal";
		oilBar.text = "Fat " + trans.ToString() + " kCal";
		pS.GetComponent<Text>().text = point.ToString() + " kCal";
	}
	public void Ultimate()
    {
		if (SanA.lockPoint == 1)
		{point = poL;
		SanA.lockPoint = 0;}
	}
	IEnumerator count()
	{
		while (true) {
			yield return new WaitForSeconds (one);
			count_calculate();
			if (sc == 3 && one == 1) {one = (one) / 3;}}
	}
	public void count_calculate()
    {
		time += 0.014f;
		time2 += 1;
		point -= 1f;
	}

	

	void OnCollisionEnter(Collision other){
		object_group(other);
		Doctor(other);
		tutorialObject_group(other);
	}

	public void object_group(Collision other)
    {
		fat_group(other);
		fruit_veget_group(other);
		Mushroom_group(other);
		Enemy_group(other);
	}
	public void fat_group(Collision other)
    {
		Burger(other);
		Chicken(other);
    }
	public void Burger(Collision other)
    {
		if (other.gameObject.tag == "Burger") { Food_detail(other, 885, 2, 378, 204, 288, 0, "885 kCal", "Protein 204 kCal", "Carbohydrate 288 kCal", "Fat 378 kCal", "Vitamin 0 Energy", true, true, false, false, false, false, false, false); }
	}
	public void Chicken(Collision other)
    {
		if (other.gameObject.tag == "Chicken") { Food_detail(other, 738, 1, 324, 360, 22, 0, "738 kCal", "Protein 360 kCal", "Carbohydrate 22 kCal", "Fat 324 kCal", "Vitamin 0 Energy", true, false, true, false, false, false, false, false); }
	}
	public void fruit_veget_group(Collision other)
    {
		PineApple(other);
		Salad(other);
		Rice(other);
		Watermelon(other);
    }
	public void PineApple(Collision other)
    {
		if (other.gameObject.tag == "Pineapple") { Food_detail(other, 150, 0, 3, 6, 156, 3, "150 kCal", "Protein 6 kCal", "Carbohydrate 156 kCal", "Fat 3 kCal", "Vitamin 3 Energy", true, false, false, true, false, false, false, false); }
	}
	public void Salad(Collision other)
    {
		if (other.gameObject.tag == "Salad") { Food_detail(other, 61, -2, 5, 12, 52, 10, "61 kCal", "Protein 12 kCal", "Carbohydrate 52 kCal", "Fat 5 kCal", "Vitamin 10 Energy", true, false, false, false, true, false, false, false); }
	}
	public void Rice( Collision other) 
	{
		if (other.gameObject.tag == "Rice") { Food_detail(other, 390, 0, 8, 32, 336, 5, "390 kCal", "Protein 32 kCal", "Carbohydrate 336 kCal", "Fat 8 kCal", "Vitamin 0 Energy", true, false, false, false, false, true, false, false); }
	}
	public void Watermelon(Collision other)
    {
		if (other.gameObject.tag == "Watermelon") { Food_detail(other, 91, 0, 5, 7, 96, 2, "91 kCal", "Protein 7 kCal", "Carbohydrate 96 kCal", "Fat 5 kCal", "Vitamin 2 Energy", true, false, false, false, false, false, true, false); }
	}
	public void Mushroom_group(Collision other)
    {
		White_mushroom(other);
		Red_mushroom(other);
    }
	public void White_mushroom(Collision other) 
	{
		if (other.gameObject.tag == "Mushroom1") { Food_detail(other, 67, -1, 8, 37, 40, 5, "67 kCal", "Protein 37 kCal", "Carbohydrate 40 kCal", "Fat 8 kCal", "Vitamin 5 Energy", true, false, false, false, false, false, false, true); }
	}
	public void Red_mushroom(Collision other)
	{
		if (other.gameObject.tag == "Mushroom2")
		{Destroy(other.gameObject);
		mushD.SetActive(true);
		hide.SetActive(true);
		show_died_text();}
	}
	public void Food_detail(Collision other, float point_plus, int Oil_plus, float trans_plus, float protein_plus, float car_plus, float vin_plus, string itemN_text, string itemP_text, string itemC_text, string itemO_text, string itemV_text, bool black_bool, bool I1_bool, bool I2_bool, bool I3_bool, bool I4_bool, bool I5_bool, bool I6_bool, bool I7_bool)
	{
		Destroy(other.gameObject);
		plus_value(point_plus, Oil_plus, trans_plus, protein_plus, car_plus, vin_plus);
		itemN.text = itemN_text;
		itemP.text = itemP_text;
		itemC.text = itemC_text;
		itemO.text = itemO_text;
		itemV.text = itemV_text;
		black.SetActive(black_bool);
		itemI1.SetActive(I1_bool);
		itemI2.SetActive(I2_bool);
		itemI3.SetActive(I3_bool);
		itemI4.SetActive(I4_bool);
		itemI5.SetActive(I5_bool);
		itemI6.SetActive(I6_bool);
		itemI7.SetActive(I7_bool);
	}
	public void plus_value(float point_plus, int Oil_plus, float trans_plus, float protein_plus, float car_plus, float vin_plus)
	{
		point += point_plus;
		PlayerMovementScript.oil += Oil_plus;
		Nutrients_value(trans_plus, protein_plus, car_plus, vin_plus);
	}
	public void Nutrients_value(float trans_plus, float protein_plus, float car_plus, float vin_plus)
    {
		trans += trans_plus;
		protein += protein_plus;
		car += car_plus;
		vin += vin_plus;
	}
	public void Enemy_group(Collision other)
    {
		Bird(other);
		Cactus(other);
    }
	public void Bird(Collision other)
    {
		if (other.gameObject.tag == "Enemy")
		{Destroy(other.gameObject);
		point -= 1000;}
	}
	public void Cactus(Collision other)
    {
		if (other.gameObject.tag == "Cactus")
		{Destroy(other.gameObject);
		point -= 300;}
	}
	public void Doctor(Collision other)
    {
		if (other.gameObject.tag == "Checked")
		{
			show.SetActive(true);
			AutoObjectSpawnerLock.die = 0;
			if (point >= pointD && point <= pointP)
			{
				show.SetActive(true);
				show.GetComponent<Text>().text = "Complete";
				Dc = 0;
				sc += 1;
				trans = 0;
				protein = 0;
				car = 0;
			}
			else
			{
				show.SetActive(false);
				docty.SetActive(true);
				hide.SetActive(true);
				show_died_text();
			}
			StartCoroutine(twoSec());
			Destroy(other.gameObject);
		}
	}
	public void tutorialObject_group(Collision other)
    {
		pine_test(other);
		redMush_test(other);
    }
	public void pine_test(Collision other)
    {
		if (other.gameObject.tag == "Test1")
		{point += 1200;
		twothor = 1;
		Destroy(other.gameObject);}
	}
	public void redMush_test(Collision other) 
	{
		if (other.gameObject.tag == "Test2")
		{
			show.SetActive(true);
			AutoObjectSpawnerLock.die = 0;
			if (point >= pointD && point <= pointP)
			{
				Dc = 0;
				sc += 1;
				twothor = 2;
			}
			else
			{
				tex.GetComponent<Text>().text = "You get score " + time.ToString();
				docty.SetActive(true);
				hide.SetActive(true);
				antiP.SetActive(false);
				Time.timeScale = 0;

			}
			StartCoroutine(twoSec());
			Destroy(other.gameObject);
		}
	}
	IEnumerator twoSec()
	{
		yield return new WaitForSeconds(2);
		show.SetActive(false);
	}

}
