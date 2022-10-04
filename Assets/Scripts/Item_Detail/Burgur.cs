using System;
using UnityEngine;

public class Burgur : MonoBehaviour
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
        collisionObject.point_plus = 885;
        collisionObject.Oil_plus = 2;
        collisionObject.trans_plus = 378;
        collisionObject.protein_plus = 204;
        collisionObject.car_plus = 288;
        collisionObject.vin_plus = 0;
        collisionObject.itemN_text = "885 kCal";
        collisionObject.itemP_text = "Protein 204 kCal";
        collisionObject.itemC_text = "Carbohydrate 288 kCal";
        collisionObject.itemO_text = "Fat 378 kCal";
        collisionObject.itemV_text = "Vitamin 0 Energy";
        collisionObject.black_bool = true;
        collisionObject.I1_bool = true;
        collisionObject.I2_bool = false;
        collisionObject.I3_bool = false;
        collisionObject.I4_bool = false;
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
