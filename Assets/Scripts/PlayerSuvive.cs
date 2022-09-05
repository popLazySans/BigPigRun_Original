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
	// Use this for initialization
	void Start () {
		
		StartCoroutine (count ());
		SetHighScore();
		SetAppearance();
		if (gen == 1) {
			point = ((10f * height) + (6.25f * weight) - (5f * age) + 5f)*1.2f;
		}
		if (gen == 2) {
			point = ((10f * height) + (6.25f * weight) - (5f * age) -161f)*1.2f;
		}
		poL = point;
		pointP = point + 250;
		pointD = point - 250;
		low.text = "Low Cal :" + pointD.ToString ();
		high.text = "High Cal :"+pointP.ToString ();
		bar.minValue = pointD;
		bar.maxValue = pointP;
	}
	public void SetHighScore()
    {
		highScore.text = "Best Score " + PlayerPrefs.GetFloat("HighScore1", 0).ToString() + " km";
	}
	public void SetAppearance()
    {
		gen =  SetGender();
		age = SetAge();
		height = SetHeight();
		weight = SetWeight();
		name = SetName();
    }
	public int SetGender()
    {
		int gender =  PlayerPrefs.GetInt("Gender",0);
		return gender;
    }
	public int SetAge()
	{
		int age = PlayerPrefs.GetInt("Age",0);
		return age;
	}
	public float SetHeight()
    {
		float height = PlayerPrefs.GetFloat("Height",0);
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
	// Update is called once per frame
	void Update () {
		down = time2 / 7700f;
		bar.value = point;
		pon = point;
		PlayerMovementScript.pot = point;
		/*if (time % 20 == 0 && time != 0) 
		{
			show.SetActive (true);
			if (point >= 10 && point <= 20) {
				show.GetComponent<Text>().text = "Complete";


			} 
			else 
			{
				show.GetComponent<Text>().text = "Failed";
				Time.timeScale = 0;
			
			}
			StartCoroutine (twoSec ());
		}*/

		if (time > PlayerPrefs.GetFloat ("HighScore5", 0)) 
		{
			if (sCoreLock5 == 0) {
				
				sCoreLock5 = 1;
			}
			if (time > PlayerPrefs.GetFloat ("HighScore5", 0) && time < PlayerPrefs.GetFloat ("HighScore4", 0)) {
				PlayerPrefs.SetFloat ("HighScore5", time);
				PlayerPrefs.SetString ("Namest5", name);

			}
				if (time > PlayerPrefs.GetFloat ("HighScore4", 0)) {
					
					if (sCoreLock4 == 0) {
						PlayerPrefs.SetFloat ("HighScore5", PlayerPrefs.GetFloat ("HighScore4", 0));
						PlayerPrefs.SetString ("Namest5", PlayerPrefs.GetString ("Namest4", ""));
						sCoreLock4 = 1;
						
					}
				if (time > PlayerPrefs.GetFloat ("HighScore4", 0) && time < PlayerPrefs.GetFloat ("HighScore3", 0)) {
					PlayerPrefs.SetFloat ("HighScore4", time);
					PlayerPrefs.SetString ("Namest4", name);
				}
					if (time > PlayerPrefs.GetFloat ("HighScore3", 0)) {
						if (sCoreLock3 == 0) {
							PlayerPrefs.SetFloat ("HighScore4", PlayerPrefs.GetFloat ("HighScore3", 0));
							PlayerPrefs.SetString ("Namest4", PlayerPrefs.GetString ("Namest3", ""));
							sCoreLock3 = 1;

						}
					if (time > PlayerPrefs.GetFloat ("HighScore3", 0) && time < PlayerPrefs.GetFloat ("HighScore2", 0)) {
						PlayerPrefs.SetFloat ("HighScore3", time);
						PlayerPrefs.SetString ("Namest3", name);
					}
					if (time > PlayerPrefs.GetFloat ("HighScore2", 0)) {
						if (sCoreLock2 == 0) {
							PlayerPrefs.SetFloat ("HighScore3", PlayerPrefs.GetFloat ("HighScore2", 0));
							PlayerPrefs.SetString ("Namest3", PlayerPrefs.GetString ("Namest2", ""));
							sCoreLock2 = 1;
						}
						if (time > PlayerPrefs.GetFloat ("HighScore2", 0) && time < PlayerPrefs.GetFloat ("HighScore1", 0)) {
							PlayerPrefs.SetFloat ("HighScore2", time);
							PlayerPrefs.SetString ("Namest2", name);
						}
						if (time > PlayerPrefs.GetFloat ("HighScore1", 0)) {
							if (sCoreLock1 == 0) {
								PlayerPrefs.SetFloat ("HighScore2", PlayerPrefs.GetFloat ("HighScore1", 0));
								PlayerPrefs.SetString ("Namest2", PlayerPrefs.GetString ("Namest1", ""));
								sCoreLock1 = 1;
							}
							PlayerPrefs.SetFloat ("HighScore1", time);
							PlayerPrefs.SetString ("Namest1", name);
							}
						}
					}
				}
		}
		if (pointP >= point && pointD <= point) {
			
			iM1.SetActive (true);
			iM2.SetActive (false);
		} 
		else 
		{
			iM1.SetActive (false);
			iM2.SetActive (true);
		}
		if (point <= 0) 
		{
			hungry.SetActive (true);
			hide.SetActive (true);
			//show.SetActive (true);
			//show.GetComponent<Text>().text = "You are weakness";
			tex.GetComponent<Text>().text ="You get score " + time.ToString()+ " km";
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
		if(sanCheck == 1){
			hide.SetActive (true);
			fatty.SetActive (true);
			tex.GetComponent<Text>().text ="You get score " + time.ToString()+ " km";
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
		/*if (time %  19 == 0 && time != 0) 
		{
			Dc = 1;
		}
		if (time % 25 == 0 && time != 0 && Dc == 1) 
		{
			show.SetActive (true);
			show.GetComponent<Text>().text = "Failed";
			Time.timeScale = 0;
		}*/
		proBar.text = "Protein " +protein.ToString() + " kCal";
		carBar.text = "Carbohydrate "+ car.ToString () + " kCal";
		vinBar.text = "Vitamin "+vin.ToString() + " kCal";
		oilBar.text = "Fat "+trans.ToString()+" kCal";
		if (AutoObjectSpawnerLock.die == 1) 
		{
			StartCoroutine (countFive());
		}
		PlayerPrefs.SetFloat ("tran", trans);
		pS.GetComponent<Text> ().text = point.ToString()+" kCal";
		if(SanA.lockPoint == 1){
			point = poL;
			SanA.lockPoint = 0;
		}
	}
	IEnumerator count()
	{
		while (true) {
			yield return new WaitForSeconds (one);
			time += 0.014f;
			time2 += 1;
			point -= 1f;
			if (sc == 3 && one == 1) {
				one = (one) / 3;
			}
		}
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
	/*IEnumerator lose()
	{
		//Time.timeScale = 0;
	}*/
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
