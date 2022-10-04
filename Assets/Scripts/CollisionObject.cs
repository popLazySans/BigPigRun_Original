using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CollisionObject : MonoBehaviour
{
	private Cause_of_Die DieManager;
	private Point pointManager;
	private Point_UI UI;
	private WaveAndStage Wave;
	public float point_plus;
	public int Oil_plus;
	public float trans_plus;
	public float protein_plus;
	public float car_plus;
	public float vin_plus;
	public string itemN_text;
	public string itemP_text;
	public string itemC_text;
	public string itemO_text;
	public string itemV_text;
	public bool black_bool;
	public bool I1_bool;
	public bool I2_bool;
	public bool I3_bool;
	public bool I4_bool;
	public bool I5_bool;
	public bool I6_bool;
	public bool I7_bool;
	public bool isFoodCollision;
	// Start is called before the first frame update
	void Start()
    {
		DieManager = GetComponent<Cause_of_Die>();
		pointManager = GetComponent<Point>();
		UI = GetComponent<Point_UI>();
		Wave = GetComponent<WaveAndStage>();
    }

    // Update is called once per frame
    void Update()
    {
    }
	void OnCollisionEnter(Collision other)
	{
		var tryGetReceiver = other.collider.GetComponent<OnTriggerReceiver>();
		if (tryGetReceiver != null)
			tryGetReceiver.NotifyOnTriggerEnter();
        if (isFoodCollision == true)
        {
			Food_detail();
		}
		
	}
	public void Food_detail()
	{
		plus_value(point_plus, Oil_plus, trans_plus, protein_plus, car_plus, vin_plus);
		UI.Set_item_text(itemN_text, itemP_text, itemC_text, itemO_text, itemV_text);
		UI.Set_item_active(black_bool, I1_bool, I2_bool, I3_bool, I4_bool, I5_bool, I6_bool, I7_bool);
	}
	public void plus_value(float point_plus, int Oil_plus, float trans_plus, float protein_plus, float car_plus, float vin_plus)
	{
		pointManager.point_current += point_plus;
		PlayerMovementScript.oil += Oil_plus;
		pointManager.Nutrients_value(trans_plus, protein_plus, car_plus, vin_plus);
	}






}
