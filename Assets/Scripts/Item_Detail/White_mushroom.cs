using System;
using UnityEngine;

public class White_mushroom : MonoBehaviour
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
        collisionObject.point_plus = 67;
        collisionObject.Oil_plus = -1;
        collisionObject.trans_plus = 8;
        collisionObject.protein_plus = 37;
        collisionObject.car_plus = 40;
        collisionObject.vin_plus = 5;
        collisionObject.itemN_text = "67 kCal";
        collisionObject.itemP_text = "Protein 37 kCal";
        collisionObject.itemC_text = "Carbohydrate 40 kCal";
        collisionObject.itemO_text = "Fat 8 kCal";
        collisionObject.itemV_text = "Vitamin 5 Energy";
        collisionObject.black_bool = true;
        collisionObject.I1_bool = false;
        collisionObject.I2_bool = false;
        collisionObject.I3_bool = false;
        collisionObject.I4_bool = false;
        collisionObject.I5_bool = false;
        collisionObject.I6_bool = false;
        collisionObject.I7_bool = true;
        collisionObject.isFoodCollision = true;
        Destroy(this.gameObject);
    }
    public void OnDestroy()
    {
        collisionObject.isFoodCollision = false;
        onTriggerReceiver.onTriggerEnter -= Set_Detail;
    }
}
