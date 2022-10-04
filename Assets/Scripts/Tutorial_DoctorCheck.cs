using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tutorial_DoctorCheck : MonoBehaviour
{
	private Cause_of_Die DieManager;
	private Point pointManager;
	private Point_UI UI;
	private WaveAndStage Wave;
	public static int tutorial_pass;
	// Start is called before the first frame update
	void Start()
    {
		DieManager = GetComponent<Cause_of_Die>();
		pointManager = GetComponent<Point>();
		UI = GetComponent<Point_UI>();
		Wave = GetComponent<WaveAndStage>();
	}

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision other)
    {
		tutorialObject_group(other);
	}
    public void tutorialObject_group(Collision other)
	{
		pine_test(other);
		redMush_test(other);
	}
	public void pine_test(Collision other)
	{
		if (other.gameObject.tag == "Test1")
		{
			pointManager.point_current += 1200;
			tutorial_pass = 1;
			Destroy(other.gameObject);
		}
	}
	public void redMush_test(Collision other)
	{
		if (other.gameObject.tag == "Test2")
		{
			UI.complete_panel.SetActive(true);
			AutoObjectSpawnerLock.die = 0;
			tutorial_doctor_check();
			Wave.prepare_to_nextwave(other.gameObject);
		}
	}
	public void tutorial_doctor_check()
	{
		if (middlePoint_tutorial()) { tutorial_doctor_pass(); }
		else { tutorial_doctor_fail(); }
	}
	public bool middlePoint_tutorial()
    {
		return pointManager.point_current >= pointManager.point_minimum && pointManager.point_current <= pointManager.point_maximum;
	}
	public void tutorial_doctor_pass()
	{
		WaveAndStage.stage += 1;
		tutorial_pass = 2;
	}
	public void tutorial_doctor_fail()
	{
		UI.Score_panel.GetComponent<Text>().text = "You get score " + Point.score_point.ToString();
		DieManager.NotPass_diePanel.SetActive(true);
		DieManager.failed_BG.SetActive(true);
		UI.Pause_Button.SetActive(false);
		Time.timeScale = 0;
	}
}
