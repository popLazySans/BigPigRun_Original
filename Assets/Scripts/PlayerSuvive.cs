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
						if (time > PlayerPrefs.GetFloat(rankScore1, 0)) { Update_Ranking("", "", rankScore1, rankName1, rankScore2, rankName2, scoreLock1); } } } }
		}

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
	public void Doctor_Denied()
    {
		if (AutoObjectSpawnerLock.die == 1)
		{
			StartCoroutine(countFive());
		}
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
			if (sc == 3 && one == 1) {one = (one) / 3;}
		}
	}
	public void count_calculate()
    {
		time += 0.014f;
		time2 += 1;
		point -= 1f;
	}
	IEnumerator countFive()
	{
		yield return new WaitForSeconds (15);
		if (AutoObjectSpawnerLock.die == 1) 
		{
			hide.SetActive (true);
			anDoc.SetActive (true);
			tex.GetComponent<Text>().text ="You get score " + time.ToString() + " km";
			tex2.GetComponent<Text>().text = "Total amount of burns is "+time2.ToString() + " kcal";
			tex3.GetComponent<Text>().text = "Total weight decreased " + down.ToString() + " kg";
			antiP.SetActive (false);
			Time.timeScale = 0;
			itemN.text = "";
			itemP.text = "";
			itemC.text = "";
			itemO.text = "";
			itemV.text = "";
			black.SetActive (false);
			itemI1.SetActive (false);
			itemI2.SetActive (false);
			itemI3.SetActive (false);
			itemI4.SetActive (false);
			itemI5.SetActive (false);
			itemI6.SetActive (false);
			itemI7.SetActive (false);
		}

	}
	IEnumerator twoSec()
	{
		yield return new WaitForSeconds (2);
		show.SetActive (false);
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Burger") {
			Destroy (other.gameObject);
			point += 885;
			PlayerMovementScript.oil += 2;
			trans += 378;
			protein += 204;
			car += 288;
			itemN.text = "885 kCal";
			itemP.text = "Protein 204 kCal";
			itemC.text = "Carbohydrate 288 kCal";
			itemO.text = "Fat 378 kCal";
			itemV.text = "Vitamin 0 Energy";
			black.SetActive (true);
			itemI1.SetActive (true);
			itemI2.SetActive (false);
			itemI3.SetActive (false);
			itemI4.SetActive (false);
			itemI5.SetActive (false);
			itemI6.SetActive (false);
			itemI7.SetActive (false);
		}
		if (other.gameObject.tag == "Chicken") {
			Destroy (other.gameObject);
			point += 738;
			PlayerMovementScript.oil += 1;
			trans += 324;
			protein += 360;
			car += 22;
			itemN.text = "738 kCal";
			itemP.text = "Protein 360 kCal";
			itemC.text = "Carbohydrate 22 kCal";
			itemO.text = "Fat 324 kCal";
			itemV.text = "Vitamin 0 Energy";
			black.SetActive (true);
			itemI1.SetActive (false);
			itemI2.SetActive (true);
			itemI3.SetActive (false);
			itemI4.SetActive (false);
			itemI5.SetActive (false);
			itemI6.SetActive (false);
			itemI7.SetActive (false);
		}
		if (other.gameObject.tag == "Pineapple") {
			Destroy (other.gameObject);
			point += 150;
			trans += 3;
			car += 156;
			protein += 6;
			vin += 3;
			itemN.text = "150 kCal";
			itemP.text = "Protein 6 kCal";
			itemC.text = "Carbohydrate 156 kCal";
			itemO.text = "Fat 3 kCal";
			itemV.text = "Vitamin 3 Energy";
			black.SetActive (true);
			itemI1.SetActive (false);
			itemI2.SetActive (false);
			itemI3.SetActive (true);
			itemI4.SetActive (false);
			itemI5.SetActive (false);
			itemI6.SetActive (false);
			itemI7.SetActive (false);
		}
		if (other.gameObject.tag == "Salad") {
			Destroy (other.gameObject);
			point += 61;
			trans += 5;
			car += 52;
			protein += 12;
			vin += 10;
			PlayerMovementScript.oil -= 2;
			itemN.text = "61 kCal";
			itemP.text = "Protein 12 kCal";
			itemC.text = "Carbohydrate 52 kCal";
			itemO.text = "Fat 5 kCal";
			itemV.text = "Vitamin 10 Energy";
			black.SetActive (true);
			itemI1.SetActive (false);
			itemI2.SetActive (false);
			itemI3.SetActive (false);
			itemI4.SetActive (true);
			itemI5.SetActive (false);
			itemI6.SetActive (false);
			itemI7.SetActive (false);
		}
		if (other.gameObject.tag == "Rice") {
			Destroy (other.gameObject);
			point += 390;
			trans += 8;
			car += 336;
			protein += 32;
			vin += 5;
			itemN.text = "390 kCal";
			itemP.text = "Protein 32 kCal";
			itemC.text = "Carbohydrate 336 kCal";
			itemO.text = "Fat 8 kCal";
			itemV.text = "Vitamin 0 Energy";
			black.SetActive (true);
			itemI1.SetActive (false);
			itemI2.SetActive (false);
			itemI3.SetActive (false);
			itemI4.SetActive (false);
			itemI5.SetActive (true);
			itemI6.SetActive (false);
			itemI7.SetActive (false);
		}
		if (other.gameObject.tag == "Watermelon") {
			Destroy (other.gameObject);
			point += 91;
			car += 96;
			trans += 5;
			protein += 7;
			vin += 2;
			itemN.text = "91 kCal";
			itemP.text = "Protein 7 kCal";
			itemC.text = "Carbohydrate 96 kCal";
			itemO.text = "Fat 5 kCal";
			itemV.text = "Vitamin 2 Energy";
			black.SetActive (true);
			itemI1.SetActive (false);
			itemI2.SetActive (false);
			itemI3.SetActive (false);
			itemI4.SetActive (false);
			itemI5.SetActive (false);
			itemI6.SetActive (true);
			itemI7.SetActive (false);
		}
		if (other.gameObject.tag == "Mushroom1") {
			Destroy (other.gameObject);
			PlayerMovementScript.oil -= 1;
			point += 67;
			trans += 8;
			car += 40;
			protein += 37;
			vin += 5;
			itemN.text = "67 kCal";
			itemP.text = "Protein 37 kCal";
			itemC.text = "Carbohydrate 40 kCal";
			itemO.text = "Fat 8 kCal";
			itemV.text = "Vitamin 5 Energy";
			black.SetActive (true);
			itemI1.SetActive (false);
			itemI2.SetActive (false);
			itemI3.SetActive (false);
			itemI4.SetActive (false);
			itemI5.SetActive (false);
			itemI6.SetActive (false);
			itemI7.SetActive (true);

		}
		if (other.gameObject.tag == "Mushroom2") {
			Destroy (other.gameObject);
			mushD.SetActive (true);
			hide.SetActive (true);
			//show.SetActive (true);
			//show.GetComponent<Text>().text = "You eat poison mushroom!!!";
			tex.GetComponent<Text> ().text = "You get score " + time.ToString ()+ " km";
			tex2.GetComponent<Text>().text = "Total amount of burns is "+time2.ToString() + " kcal";
			tex3.GetComponent<Text>().text = "Total weight decreased " + down.ToString() + " kg";
			antiP.SetActive (false);
			itemN.text = "";
			itemP.text = "";
			itemC.text = "";
			itemO.text = "";
			itemV.text = "";
			black.SetActive (false);
			itemI1.SetActive (false);
			itemI2.SetActive (false);
			itemI3.SetActive (false);
			itemI4.SetActive (false);
			itemI5.SetActive (false);
			itemI6.SetActive (false);
			itemI7.SetActive (false);
			Time.timeScale = 0;
		}
		if (other.gameObject.tag == "Enemy") {
			Destroy (other.gameObject);
			point -= 1000;

		}
		if (other.gameObject.tag == "Cactus") {
			Destroy (other.gameObject);
			point -= 300;

		}
		if (other.gameObject.tag == "Test1") {
			point += 1200;
			twothor = 1;
			Destroy (other.gameObject);
		}
		if (other.gameObject.tag == "Checked") {
			show.SetActive (true);
			AutoObjectSpawnerLock.die = 0;
			if (point >= pointD && point <= pointP) {
				show.SetActive (true);
				show.GetComponent<Text> ().text = "Complete";
				Dc = 0;
				sc += 1;
				trans = 0;
				protein = 0;
				car = 0;
			} else {
				show.SetActive (false);
				tex.GetComponent<Text> ().text = "You get score " + time.ToString ()+ " km";
				tex2.GetComponent<Text>().text = "Total amount of burns is "+time2.ToString() + " kcal";
				tex3.GetComponent<Text>().text = "Total weight decreased " + down.ToString() + " kg";
				docty.SetActive (true);
				hide.SetActive (true);
				antiP.SetActive (false);
				itemN.text = "";
				itemP.text = "";
				itemC.text = "";
				itemO.text = "";
				itemV.text = "";
				black.SetActive (false);
				itemI1.SetActive (false);
				itemI2.SetActive (false);
				itemI3.SetActive (false);
				itemI4.SetActive (false);
				itemI5.SetActive (false);
				itemI6.SetActive (false);
				itemI7.SetActive (false);
				Time.timeScale = 0;

			}



			StartCoroutine (twoSec ());
			Destroy (other.gameObject);
		}
		if (other.gameObject.tag == "Test2") {
			show.SetActive (true);
			AutoObjectSpawnerLock.die = 0;
			if (point >= pointD && point <= pointP) {
				Dc = 0;
				sc += 1;
				twothor = 2;
			} else {
				//show.GetComponent<Text>().text = "ไม่ผ่านเกณฑ์";
				tex.GetComponent<Text> ().text = "You get score " + time.ToString ();
				docty.SetActive (true);
				hide.SetActive (true);
				antiP.SetActive (false);
				Time.timeScale = 0;

			}
			StartCoroutine (twoSec ());
			Destroy (other.gameObject);
		}
	}
}
