using System;
using UnityEngine;

public class Salad : MonoBehaviour
{
    OnTriggerReceiver onTriggerReceiver;
    GameObject player;
    CollisionObject collisionObject;

    public void Start()
    {
        player = GameObject.FindWithTag("Player");
        collisionObject = player.GetComponent<CollisionObject>();
        onTriggerReceiver = GetComponent<OnTriggerReceiver>();
        onTriggerReceiver.onTriggerEnter += Set_Detail;
    }
    public void Set_Detail()
    {
        collisionObject.point_plus = 61;
        collisionObject.Oil_plus = -2;
        collisionObject.trans_plus = 5;
        collisionObject.protein_plus = 12;
        collisionObject.car_plus = 52;
        collisionObject.vin_plus = 10;
        collisionObject.itemN_text = "61 kCal";
        collisionObject.itemP_text = "Protein 12 kCal";
        collisionObject.itemC_text = "Carbohydrate 52 kCal";
        collisionObject.itemO_text = "Fat 5 kCal";
        collisionObject.itemV_text = "Vitamin 10 Energy";
        collisionObject.black_bool = true;
        collisionObject.I1_bool = false;
        collisionObject.I2_bool = false;
        collisionObject.I3_bool = false;
        collisionObject.I4_bool = true;
        collisionObject.I5_bool = false;
        collisionObject.I6_bool = false;
        collisionObject.I7_bool = false;
        collisionObject.isFoodCollision = true;
        Destroy(this.gameObject);
    }
    public void OnDestroy()
    {
        collisionObject.isFoodCollision = false;
        onTriggerReceiver.onTriggerEnter -= Set_Detail;
    }
}
