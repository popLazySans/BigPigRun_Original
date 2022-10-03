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
		object_group(other);
		Doctor(other);
		
	}

	public void object_group(Collision other)
	{
		fat_group(other);
		fruit_veget_group(other);
		Mushroom_group(other);
		Enemy_group(other);
	}
	public void fat_group(Collision other)
	{
		Burger(other);
		Chicken(other);
	}
	public void Burger(Collision other)
	{
		if (other.gameObject.tag == "Burger") { Food_detail(other, 885, 2, 378, 204, 288, 0, "885 kCal", "Protein 204 kCal", "Carbohydrate 288 kCal", "Fat 378 kCal", "Vitamin 0 Energy", true, true, false, false, false, false, false, false); }
	}
	public void Chicken(Collision other)
	{
		if (other.gameObject.tag == "Chicken") { Food_detail(other, 738, 1, 324, 360, 22, 0, "738 kCal", "Protein 360 kCal", "Carbohydrate 22 kCal", "Fat 324 kCal", "Vitamin 0 Energy", true, false, true, false, false, false, false, false); }
	}
	public void fruit_veget_group(Collision other)
	{
		PineApple(other);
		Salad(other);
		Rice(other);
		Watermelon(other);
	}
	public void PineApple(Collision other)
	{
		if (other.gameObject.tag == "Pineapple") { Food_detail(other, 150, 0, 3, 6, 156, 3, "150 kCal", "Protein 6 kCal", "Carbohydrate 156 kCal", "Fat 3 kCal", "Vitamin 3 Energy", true, false, false, true, false, false, false, false); }
	}
	public void Salad(Collision other)
	{
		if (other.gameObject.tag == "Salad") { Food_detail(other, 61, -2, 5, 12, 52, 10, "61 kCal", "Protein 12 kCal", "Carbohydrate 52 kCal", "Fat 5 kCal", "Vitamin 10 Energy", true, false, false, false, true, false, false, false); }
	}
	public void Rice(Collision other)
	{
		if (other.gameObject.tag == "Rice") { Food_detail(other, 390, 0, 8, 32, 336, 5, "390 kCal", "Protein 32 kCal", "Carbohydrate 336 kCal", "Fat 8 kCal", "Vitamin 0 Energy", true, false, false, false, false, true, false, false); }
	}
	public void Watermelon(Collision other)
	{
		if (other.gameObject.tag == "Watermelon") { Food_detail(other, 91, 0, 5, 7, 96, 2, "91 kCal", "Protein 7 kCal", "Carbohydrate 96 kCal", "Fat 5 kCal", "Vitamin 2 Energy", true, false, false, false, false, false, true, false); }
	}
	public void Mushroom_group(Collision other)
	{
		White_mushroom(other);
		Red_mushroom(other);
	}
	public void White_mushroom(Collision other)
	{
		if (other.gameObject.tag == "Mushroom1") { Food_detail(other, 67, -1, 8, 37, 40, 5, "67 kCal", "Protein 37 kCal", "Carbohydrate 40 kCal", "Fat 8 kCal", "Vitamin 5 Energy", true, false, false, false, false, false, false, true); }
	}
	public void Red_mushroom(Collision other)
	{
		if (other.gameObject.tag == "Mushroom2")
		{
			Destroy(other.gameObject);
			DieManager.Poison_diePanel.SetActive(true);
			DieManager.failed_BG.SetActive(true);
			DieManager.show_died_text();
		}
	}
	public void Food_detail(Collision other, float point_plus, int Oil_plus, float trans_plus, float protein_plus, float car_plus, float vin_plus, string itemN_text, string itemP_text, string itemC_text, string itemO_text, string itemV_text, bool black_bool, bool I1_bool, bool I2_bool, bool I3_bool, bool I4_bool, bool I5_bool, bool I6_bool, bool I7_bool)
	{
		Destroy(other.gameObject);
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
	public void Enemy_group(Collision other)
	{
		Bird(other);
		Cactus(other);
	}
	public void Bird(Collision other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			Destroy(other.gameObject);
			pointManager.point_current -= 1000;
		}
	}
	public void Cactus(Collision other)
	{
		if (other.gameObject.tag == "Cactus")
		{
			Destroy(other.gameObject);
			 pointManager.point_current -= 300;
		}
	}
	public void Doctor(Collision other)
	{
		if (other.gameObject.tag == "Checked")
		{
			UI.complete_panel.SetActive(true);
			AutoObjectSpawnerLock.die = 0;
			Wave.Doctor_check();
			Wave.prepare_to_nextwave(other);
		}
	}




}