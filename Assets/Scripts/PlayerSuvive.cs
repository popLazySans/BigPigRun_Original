using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerSuvive : MonoBehaviour {
	

	public static float score_point;

	public GameObject complete_panel;
	public GameObject Point_panel;
	public static float Tranfat_value;
	public static float Protein_value;
	public static float Carbo_value;
	public static float Vitamin_value;
	public static float point_toStatic;

	public GameObject Green_weighter;
	public GameObject Red_weighter;
	public GameObject Pause_Button;
	public GameObject Score_panel;
	public GameObject Burn_amout_panel;
	public GameObject Weight_decreased_panel;
	public Text highScore;
	public GameObject failed_BG;
	public GameObject Poison_diePanel;
	public GameObject Hungry_diePanel;
	public GameObject Fat_diePanel;
	public GameObject NotPass_diePanel;
	public GameObject DontGetDocter_diePanel;
	public Slider Calories_slide;
	public GameObject hamburger_picture;
	public GameObject chicken_picture;
	public GameObject pineapple_picture;
	public GameObject vegetable_picture;
	public GameObject rice_picture;
	public GameObject watermelon_picture;
	public GameObject mushroom_picture;
	public Text itemName;
	public Text itemProtein;
	public Text itemCarbohydrate;
	public Text itemTranfat;
	public Text itemVitamin;
	public float freqTime = 0.01f;

	
	
	public Text minimum_calories_text;
	public Text maximum_calories_text;
	public static int TranfatCheck;
	public static int tutorial_pass;
	public Text protein_text;
	public Text carbohydrate_text;
	public Text vintamin_text;
	public Text tranfat_text;
	public GameObject food_detail_panel;
	public int ScoreNo1;
	public int ScoreNo2;
	public int ScoreNo3;
	public int ScoreNo4;
	public int ScoreNo5;

	public static int sc = 1;
	void Start() {
		StartCoroutine(count());
		SetHighScore();
		
		
		
	}
	public void SetHighScore()
	{
		highScore.text = "Best Score " + PlayerPrefs.GetFloat("HighScore1", 0).ToString() + " km";
	}
	

	

	
	public void SetCalText()
	{
		minimum_calories_text.text = "Low Cal :" + point_minimum.ToString();
		maximum_calories_text.text = "High Cal :" + point_maximum.ToString();
	}
	public void SetCalBar()
	{
		Calories_slide.minValue = point_minimum;
		Calories_slide.maxValue = point_maximum;
	}

	void Update() {
		
		ChangeColor_Weighter();
		Die_Statement();
		Ultimate();
	}

	public void SetValueToPoint()
	{
		Calories_slide.value = point_current;
		point_toStatic = point_current;
		PlayerMovementScript.pot = point_current;
	}
	public void HightScore_Current()
	{
		Rank_Checker("HighScore5", "Namest5", "HighScore4", "Namest4", "HighScore3", "Namest3", "HighScore2", "Namest2", "HighScore1", "Namest1", ScoreNo5, ScoreNo4, ScoreNo3, ScoreNo2, ScoreNo1);
	}
	public void Rank_Checker(string rankScore5, string rankName5, string rankScore4, string rankName4, string rankScore3, string rankName3, string rankScore2, string rankName2, string rankScore1, string rankName1, int scoreLock5, int scoreLock4, int scoreLock3, int scoreLock2, int scoreLock1)
	{
		if (score_point > PlayerPrefs.GetFloat(rankScore5, 0)) { Update_Ranking(rankScore4, rankName4, rankScore5, rankName5, "", "", scoreLock5);
			if (score_point > PlayerPrefs.GetFloat(rankScore4, 0)) { Update_Ranking(rankScore3, rankName3, rankScore4, rankName4, rankScore5, rankName5, scoreLock4);
				if (score_point > PlayerPrefs.GetFloat(rankScore3, 0)) { Update_Ranking(rankScore2, rankName2, rankScore3, rankName3, rankScore4, rankName4, scoreLock3);
					if (score_point > PlayerPrefs.GetFloat(rankScore2, 0)) { Update_Ranking(rankScore1, rankName1, rankScore2, rankName2, rankScore3, rankName3, scoreLock2);
						if (score_point > PlayerPrefs.GetFloat(rankScore1, 0)) { Update_Ranking("", "", rankScore1, rankName1, rankScore2, rankName2, scoreLock1); } } } }}
	}
	public void Update_Ranking(string rankScorePlus, string rankNamePlus, string rankScore, string rankName, string rankScoreDe, string rankNameDe, int scoreLock)
	{
		if (scoreLock == 0) { if (rankScoreDe != "") { reset_HighScore(rankScoreDe, rankNameDe, rankScore, rankName); } scoreLock = 1; }
		if (rankScorePlus == "" || (score_point > PlayerPrefs.GetFloat(rankScore, 0) && score_point < PlayerPrefs.GetFloat(rankScorePlus, 0))) { set_HighScore(rankScore, rankName); }
	}
	public void reset_HighScore(string rankScoreDe, string rankNameDe, string rankScore, string rankName)
	{
		PlayerPrefs.SetFloat(rankScoreDe, PlayerPrefs.GetFloat(rankScore, 0));
		PlayerPrefs.SetString(rankNameDe, PlayerPrefs.GetString(rankName, ""));
	}
	public void set_HighScore(string rankScore, string rankName)
	{
		PlayerPrefs.SetFloat(rankScore, score_point);
		PlayerPrefs.SetString(rankName, name);
	}
	public void ChangeColor_Weighter()
	{
		if (point_maximum >= point_current && point_minimum <= point_current) { green_weight(); }
		else { red_weight(); }
	}
	public void green_weight()
	{
		Green_weighter.SetActive(true);
		Red_weighter.SetActive(false);
	}
	public void red_weight()
	{
		Green_weighter.SetActive(false);
		Red_weighter.SetActive(true);
	}
	public void Die_Statement()
	{
		Hungry();
		Fatty();
		Doctor_Denied();
	}
	public void Hungry()
	{
		if (point_current <= 0)
		{ Hungry_diePanel.SetActive(true);
			failed_BG.SetActive(true);
			show_died_text(); }
	}
	public void Fatty()
	{
		if (TranfatCheck == 1)
		{ failed_BG.SetActive(true);
			Fat_diePanel.SetActive(true);
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
		{failed_BG.SetActive(true);
		DontGetDocter_diePanel.SetActive(true);
		show_died_text();}
	}
	public void show_died_text()
	{
		Summary_text();
		Pause_Button.SetActive(false);
		Time.timeScale = 0;
		Item_text();
		Set_item_object();
	}
	public void Summary_text()
	{
		Score_panel.GetComponent<Text>().text = "You get score " + score_point.ToString() + " km";
		Burn_amout_panel.GetComponent<Text>().text = "Total amount of burns is " + current_amout_burn.ToString() + " kcal";
		Weight_decreased_panel.GetComponent<Text>().text = "Total weight decreased " + current_weight_decrease.ToString() + " kg";
	}
	public void Item_text ()
	{
		itemName.text = "";
		itemProtein.text = "";
		itemCarbohydrate.text = "";
		itemTranfat.text = "";
		itemVitamin.text = "";
	}
	public void Set_item_object()
    {
		food_detail_panel.SetActive(false);
		hamburger_picture.SetActive(false);chicken_picture.SetActive(false);pineapple_picture.SetActive(false);vegetable_picture.SetActive(false);rice_picture.SetActive(false);watermelon_picture.SetActive(false);mushroom_picture.SetActive(false);
	}
	
	public void Set_Nutrients_text()
    {
		protein_text.text = "Protein " + Protein_value.ToString() + " kCal";
		carbohydrate_text.text = "Carbohydrate " + Carbo_value.ToString() + " kCal";
		vintamin_text.text = "Vitamin " + Vitamin_value.ToString() + " kCal";
		tranfat_text.text = "Fat " + Tranfat_value.ToString() + " kCal";
		Point_panel.GetComponent<Text>().text = point_current.ToString() + " kCal";
	}
	public void Ultimate()
    {
		if (SanA.lockPoint == 1)
		{point_current = point_origin;
		SanA.lockPoint = 0;}
	}
	IEnumerator count()
	{
		while (true) {
			yield return new WaitForSeconds (freqTime);
			count_calculate();
			if (sc == 3 && freqTime == 1) {freqTime = (freqTime) / 3;}}
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
		Poison_diePanel.SetActive(true);
		failed_BG.SetActive(true);
		show_died_text();}
	}
	public void Food_detail(Collision other, float point_plus, int Oil_plus, float trans_plus, float protein_plus, float car_plus, float vin_plus, string itemN_text, string itemP_text, string itemC_text, string itemO_text, string itemV_text, bool black_bool, bool I1_bool, bool I2_bool, bool I3_bool, bool I4_bool, bool I5_bool, bool I6_bool, bool I7_bool)
	{
		Destroy(other.gameObject);
		plus_value(point_plus, Oil_plus, trans_plus, protein_plus, car_plus, vin_plus);
		Set_item_text(itemN_text,itemP_text,itemC_text,itemO_text,itemV_text);
		Set_item_active(black_bool,I1_bool,I2_bool,I3_bool,I4_bool,I5_bool,I6_bool,I7_bool);
	}
	public void plus_value(float point_plus, int Oil_plus, float trans_plus, float protein_plus, float car_plus, float vin_plus)
	{
		point_current += point_plus;
		PlayerMovementScript.oil += Oil_plus;
		Nutrients_value(trans_plus, protein_plus, car_plus, vin_plus);
	}
	public void Nutrients_value(float trans_plus, float protein_plus, float car_plus, float vin_plus)
    {
		Tranfat_value += trans_plus;
		Protein_value += protein_plus;
		Carbo_value += car_plus;
		Vitamin_value += vin_plus;
	}
	public void Set_item_text(string itemN_text, string itemP_text, string itemC_text, string itemO_text, string itemV_text) 
	{
		itemName.text = itemN_text;
		itemProtein.text = itemP_text;
		itemCarbohydrate.text = itemC_text;
		itemTranfat.text = itemO_text;
		itemVitamin.text = itemV_text;
	}
	public void Set_item_active(bool black_bool, bool I1_bool, bool I2_bool, bool I3_bool, bool I4_bool, bool I5_bool, bool I6_bool, bool I7_bool)
    {
		food_detail_panel.SetActive(black_bool);hamburger_picture.SetActive(I1_bool);chicken_picture.SetActive(I2_bool);pineapple_picture.SetActive(I3_bool);vegetable_picture.SetActive(I4_bool);rice_picture.SetActive(I5_bool);watermelon_picture.SetActive(I6_bool);mushroom_picture.SetActive(I7_bool);
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
		point_current -= 1000;}
	}
	public void Cactus(Collision other)
    {
		if (other.gameObject.tag == "Cactus")
		{Destroy(other.gameObject);
		point_current -= 300;}
	}
	public void Doctor(Collision other)
    {
		if (other.gameObject.tag == "Checked")
		{complete_panel.SetActive(true);
		AutoObjectSpawnerLock.die = 0;
		Doctor_check();
		prepare_to_nextwave(other);}
	}
	public void Doctor_check()
    {
		if (point_current >= point_minimum && point_current <= point_maximum) { Doctor_complete_check(); }
		else { Doctor_die_check(); }
	}
	public void Doctor_complete_check()
    {
		complete_panel.SetActive(true);
		complete_panel.GetComponent<Text>().text = "Complete";
		Doctor_reset_value();
	}
	public void Doctor_reset_value()
    {
		sc += 1;
		Tranfat_value = 0;
		Protein_value = 0;
		Carbo_value = 0;
	}
	public void Doctor_die_check()
    {
		complete_panel.SetActive(false);
		NotPass_diePanel.SetActive(true);
		failed_BG.SetActive(true);
		show_died_text();
	}
	public void prepare_to_nextwave(Collision other)
    {
		StartCoroutine(twoSec());
		Destroy(other.gameObject);
	}

	public void tutorialObject_group(Collision other)
    {
		pine_test(other);
		redMush_test(other);
    }
	public void pine_test(Collision other)
    {
		if (other.gameObject.tag == "Test1")
		{point_current += 1200;
		tutorial_pass = 1;
		Destroy(other.gameObject);}
	}
	public void redMush_test(Collision other) 
	{
		if (other.gameObject.tag == "Test2")
		{complete_panel.SetActive(true);
		AutoObjectSpawnerLock.die = 0;
		tutorial_doctor_check();
		prepare_to_nextwave(other);}
	}
	public void tutorial_doctor_check()
    {
		if (point_current >= point_minimum && point_current <= point_maximum){tutorial_doctor_pass();}
		else{tutorial_doctor_fail();}
	}
	public void tutorial_doctor_pass()
    {
		sc += 1;
		tutorial_pass = 2;
	}
	public void tutorial_doctor_fail()
    {
		Score_panel.GetComponent<Text>().text = "You get score " + score_point.ToString();
		NotPass_diePanel.SetActive(true);
		failed_BG.SetActive(true);
		Pause_Button.SetActive(false);
		Time.timeScale = 0;
	}
	IEnumerator twoSec()
	{
		yield return new WaitForSeconds(2);
		complete_panel.SetActive(false);
	}

}
