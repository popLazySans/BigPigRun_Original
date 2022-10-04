using System;
using UnityEngine;

public class PineApple : MonoBehaviour
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
        collisionObject.point_plus = 150;
        collisionObject.Oil_plus = 0;
        collisionObject.trans_plus = 3;
        collisionObject.protein_plus = 6;
        collisionObject.car_plus = 156;
        collisionObject.vin_plus = 3;
        collisionObject.itemN_text = "150 kCal";
        collisionObject.itemP_text = "Protein 6 kCal";
        collisionObject.itemC_text = "Carbohydrate 156 kCal";
        collisionObject.itemO_text = "Fat 3 kCal";
        collisionObject.itemV_text = "Vitamin 3 Energy";
        collisionObject.black_bool = true;
        collisionObject.I1_bool = false;
        collisionObject.I2_bool = false;
        collisionObject.I3_bool = true;
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
