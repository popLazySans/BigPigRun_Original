using System;
using UnityEngine;
using UnityEngine.UI;
public class Doctor : MonoBehaviour
{
    OnTriggerReceiver onTriggerReceiver;
    GameObject player;
    Point_UI UI;
    WaveAndStage Wave;

    public void Start()
    {
        player = GameObject.FindWithTag("Player");
        UI = player.GetComponent<Point_UI>();
        Wave = player.GetComponent<WaveAndStage>();
        onTriggerReceiver = GetComponent<OnTriggerReceiver>();
        Debug.Log("Checked");
        onTriggerReceiver.onTriggerEnter += Check;
    }
    public void Check()
    {
        UI.complete_panel.SetActive(true);
        AutoObjectSpawnerLock.die = 0;
        Wave.Doctor_check();
        Wave.prepare_to_nextwave(gameObject);
    }
    public void OnDestroy()
    {
        onTriggerReceiver.onTriggerEnter -= Check;
    }
}