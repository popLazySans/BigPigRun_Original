using System;
using UnityEngine;

public class Rice : MonoBehaviour
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
        collisionObject.point_plus = 390;
        collisionObject.Oil_plus = 0;
        collisionObject.trans_plus = 8;
        collisionObject.protein_plus = 32;
        collisionObject.car_plus = 336;
        collisionObject.vin_plus = 5;
        collisionObject.itemN_text = "390 kCal";
        collisionObject.itemP_text = "Protein 32 kCal";
        collisionObject.itemC_text = "Carbohydrate 336 kCal";
        collisionObject.itemO_text = "Fat 8 kCal";
        collisionObject.itemV_text = "Vitamin 0 Energy";
        collisionObject.black_bool = true;
        collisionObject.I1_bool = false;
        collisionObject.I2_bool = false;
        collisionObject.I3_bool = false;
        collisionObject.I4_bool = false;
        collisionObject.I5_bool = true;
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
