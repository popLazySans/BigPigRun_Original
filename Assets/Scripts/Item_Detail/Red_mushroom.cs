using System;
using UnityEngine;

public class Red_mushroom : MonoBehaviour
{
    OnTriggerReceiver onTriggerReceiver;
    GameObject player;
    Cause_of_Die DieManager;

    public void Start()
    {
        player = GameObject.FindWithTag("Player");
        DieManager = player.GetComponent<Cause_of_Die>();
        onTriggerReceiver = GetComponent<OnTriggerReceiver>();
        onTriggerReceiver.onTriggerEnter += Die_Effect;
    }
    public void Die_Effect()
    {
        DieManager.Poison_diePanel.SetActive(true);
        DieManager.failed_BG.SetActive(true);
        DieManager.show_died_text();
    }
    public void OnDestroy()
    {
        onTriggerReceiver.onTriggerEnter -= Die_Effect;
    }
}
