using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cause_of_Die : MonoBehaviour
{
	private Point pointManager;
	public GameObject failed_BG;
	public GameObject Poison_diePanel;
	public GameObject Hungry_diePanel;
	public GameObject Fat_diePanel;
	public GameObject NotPass_diePanel;
	public GameObject DontGetDocter_diePanel;
	public static int TranfatCheck;
	private Point_UI UI;
	// Start is called before the first frame update
	void Start()
    {
		pointManager = GetComponent<Point>();
		UI = GetComponent<Point_UI>();
    }

    // Update is called once per frame
    void Update()
    {
		Die_Statement();
	}
	public void Die_Statement()
	{
		Hungry();
		Fatty();
		Doctor_Denied();
	}
	public void Hungry()
	{
		if (pointManager.point_current <= 0)
		{
			Hungry_diePanel.SetActive(true);
			failed_BG.SetActive(true);
			show_died_text();
		}
	}
	public void Fatty()
	{
		if (TranfatCheck == 1)
		{
			failed_BG.SetActive(true);
			Fat_diePanel.SetActive(true);
			show_died_text();
			Time.timeScale = 0;
		}
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
		{
			failed_BG.SetActive(true);
			DontGetDocter_diePanel.SetActive(true);
			show_died_text();
		}
	}
	public void show_died_text()
	{
		UI.Summary_text();
		UI.Pause_Button.SetActive(false);
		Time.timeScale = 0;
		UI.Item_text_Disable();
		UI.Set_item_object();
	}


}
