using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sTalk : MonoBehaviour {

	public int sceneNum;
	public Text text;
	public GameObject img1;
	public GameObject img2;
	public GameObject img3;
	public GameObject img4;
	public GameObject img5;
	public GameObject img6;
	public GameObject img7;
	public GameObject img8;
	public GameObject img9;
	public GameObject talk1;
	public GameObject talk2;
	public GameObject talk3;
	public GameObject talk4;
	public GameObject talk5;


	// Use this for initialization
	void Start () {
		text.text = "ณ ปราสาทแห่งหนึ่ง";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void nextS()
	{
		
		if (sceneNum == 0) 
		{
			img1.SetActive (false);
			img2.SetActive (true);
			text.text = "มีเจ้าชายหมูเป็นผู้ปกครองปราสาท";

		}
		if (sceneNum == 1) 
		{
			talk1.SetActive (true);
		}
		if (sceneNum == 2) 
		{
			text.text = "แต่เจ้าชายหมูคนนั้นได้ตกหลุมรักเจ้าหญิงจากอีกเมือง";
			img2.SetActive (false);
			img3.SetActive (true);
			talk1.SetActive (false);
		}
		if (sceneNum == 3) 
		{
			talk2.SetActive (true);
		}
		if (sceneNum == 4) 
		{
			text.text = "แต่เจ้าชายหมูไม่กล้าที่จะบอกเจ้าหญิงเนื่องจากไม่ชอบตัวเองที่อ้วนแบบนี้";
			img4.SetActive (true);
			img3.SetActive (false);
			talk2.SetActive (false);
		}
		if (sceneNum == 5) 
		{
			talk3.SetActive (true);
		}
		if (sceneNum == 6) 
		{
			text.text = "เขาจึงไปปรึกษาหมอประจำตัว";
			talk3.SetActive (false);
			img4.SetActive (false);
			img5.SetActive (true);
		}
		if (sceneNum == 7) 
		{
			talk4.SetActive (true);
		}
		if (sceneNum == 8) 
		{
			text.text = "หมอคนนี้กลับได้บอกสถานที่ที่สามารถลดน้ำหนักได้!?";
			talk4.SetActive (false);
			img5.SetActive (false);
			img6.SetActive (true);
		}
		if (sceneNum == 9) 
		{
			text.text = "ในที่สุดเขาก็พบสถานที่นั้น แต่กลับเป็นห้วงมิติปริศนาที่อยู่ตรงหน้า";
			img6.SetActive (false);
			img7.SetActive (true);
		}
		if (sceneNum == 10) 
		{
			talk5.SetActive (true);
		}
		if (sceneNum == 11) 
		{
			text.text = "เจ้าชายหมูกลับเผลอเข้าไปในมิตินั้น";
			talk5.SetActive (false);
			img7.SetActive (false);
			img8.SetActive (true);
		}
		if (sceneNum == 12) 
		{
			text.text = "ต่อไปคือของจริง คราวนี้ละ ได้เวลาลดน้ำหนักของเจ้าชายหมูกันแล้ว!!!!";
			img8.SetActive (false);
			img9.SetActive (true);
		}
		if (sceneNum == 13) 
		{
			SceneManager.LoadScene ("SpherePlayTest");
			Link.off = 1;
		}
		sceneNum += 1;
	}

}
