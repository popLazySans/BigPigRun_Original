using System;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    OnTriggerReceiver onTriggerReceiver;
    GameObject player;
    Point pointManager;


    public void Start()
    {
        player = GameObject.FindWithTag("Player");
        pointManager = player.GetComponent<Point>();
        onTriggerReceiver = GetComponent<OnTriggerReceiver>();
        onTriggerReceiver.onTriggerEnter += Attacked;
    }
    public void Attacked()
    {
        pointManager.point_current -= 300;
    }
    public void OnDestroy()
    {
        onTriggerReceiver.onTriggerEnter -= Attacked;
    }
}
