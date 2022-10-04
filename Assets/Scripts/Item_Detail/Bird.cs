using System;
using UnityEngine;

public class Bird : MonoBehaviour
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
        pointManager.point_current -= 1000;
    }
    public void OnDestroy()
    {
        onTriggerReceiver.onTriggerEnter -= Attacked;
    }
}
