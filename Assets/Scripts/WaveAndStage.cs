using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WaveAndStage : MonoBehaviour
{
    private Cause_of_Die DieManager;
    private Point pointManager;
    private Point_UI UI;
    public static int stage = 1;
    public float freqTime = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(count());
        DieManager = GetComponent<Cause_of_Die>();
        pointManager = GetComponent<Point>();
        UI = GetComponent<Point_UI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Doctor_check()
    {
        if (pointManager.point_current >= pointManager.point_minimum && pointManager.point_current <= pointManager.point_maximum) { Doctor_complete_check(); }
        else { Doctor_die_check(); }
    }
    public void Doctor_complete_check()
    {
        UI.complete_panel.SetActive(true);
        UI.complete_panel.GetComponent<Text>().text = "Complete";
        pointManager.Doctor_reset_value();
    }
    public void Doctor_die_check()
    {
        UI.complete_panel.SetActive(false);
        DieManager.NotPass_diePanel.SetActive(true);
        DieManager.failed_BG.SetActive(true);
        DieManager.show_died_text();
    }
    public void prepare_to_nextwave(Collision other)
    {
        StartCoroutine(twoSec());
        Destroy(other.gameObject);
    }
    IEnumerator twoSec()
    {
        yield return new WaitForSeconds(2);
        UI.complete_panel.SetActive(false);
    }
    IEnumerator count()
    {
        while (true)
        {
            yield return new WaitForSeconds(freqTime);
           pointManager.count_calculate();
            if (stage == 3 && freqTime == 1) { freqTime = (freqTime) / 3; }
        }
    }
}
