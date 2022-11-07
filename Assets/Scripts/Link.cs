 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class Link : MonoBehaviour {
	[SerializeField] GameObject foodListPage;
	public static int off;
	public int tm;
	//public BGSoundScript bg;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		if (tm == 1) {
			Time.timeScale = 1;
		}
	}
	public void LinkToPlay()
	{
		SceneManager.LoadScene("SpherePlay1");
		off = 1;
		Time.timeScale = 1;
	}
	public void LinkToExit()
	{
		Application.Quit ();
	}
	public void LinkToSet(){
		SceneManager.LoadScene ("Setting");
	}
	public void LinkToHow(){
		SceneManager.LoadScene ("how");
	}
	public void LinkToMain(){		
		SceneManager.LoadScene ("main");
		
		off = 0;
		PlayerMovementScript.oil = 0;
		WaveAndStage.stage = 1;
		Point.score_point = 0;
		Point.Tranfat_value = 0;
		Point.Carbo_value = 0;
		Point.Protein_value = 0;
		Point.Vitamin_value = 0;
		tm =1;
		AutoObjectSpawnerLock.die = 0;
	}
	public void CloseDataTab()
	{
		foodListPage.SetActive(false);
	}

	public void OpenDataTab()
	{
		foodListPage.SetActive(true);
	}

	public void LinkToScore(){
		SceneManager.LoadScene ("Score");
	}
	public void LinkToEaster(){
		SceneManager.LoadScene ("mainE");
	}
	public void LinkToInfo(){
		SceneManager.LoadScene ("Info");
	}
	public void LinkToNext(){
		SceneManager.LoadScene ("Info2");
	}
	public void Bird(){
		SceneManager.LoadScene ("bird");
	}
	public void Ham(){
		SceneManager.LoadScene ("hamburger");
	}
	public void Chicken(){
		SceneManager.LoadScene ("chicken");
	}
	public void Doctor(){
		SceneManager.LoadScene ("doctor");
	}
	public void Mush1(){
		SceneManager.LoadScene ("mushroom1");
	}
	public void Mush2(){
		SceneManager.LoadScene ("mushroom2");
	}
	public void Pine(){
		SceneManager.LoadScene ("pineapple");
	}
	public void Sushi(){
		SceneManager.LoadScene ("sushi");
	}
	public void Salad(){
		SceneManager.LoadScene ("salad");
	}
	public void Watermelon(){
		SceneManager.LoadScene ("watermelon");
	}
	public void Cactus(){
		SceneManager.LoadScene ("cactus");
	}
	public void Restart(){
		
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name, LoadSceneMode.Single);
		Point.score_point = 0;
		tm = 1;
		PlayerMovementScript.oil = 0;
		WaveAndStage.stage = 1;
		AutoObjectSpawnerLock.die = 0;
		Point.Tranfat_value = 0;
		Point.Carbo_value = 0;
		Point.Protein_value = 0;
		Point.Vitamin_value = 0;
	}
	public void Gen()
	{
		SceneManager.LoadScene ("gen");
	}
	public void LinkToStory (){
		SceneManager.LoadScene ("cut");
	}
	public void comTwo(){
		Tutorial_DoctorCheck.tutorial_pass = 3;
	}
	public void LinkToTuTwo(){
		SceneManager.LoadScene ("SpherePlayTest");
		off = 1;
	}
}

