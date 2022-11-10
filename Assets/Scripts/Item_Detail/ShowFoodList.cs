using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowFoodList : MonoBehaviour
{
    [SerializeField] Text foodName;
    [SerializeField] Text energyNum;
    [SerializeField] Text proteinNum;
    [SerializeField] Text carbohydateNum;
    [SerializeField] Text fatNum;
    [SerializeField] Text vitaminNum;


    public void SetFoodData(FoodData foodDataBase)
	{
        foodName.text = foodDataBase.name;
        energyNum.text = foodDataBase.energy.ToString();
        proteinNum.text = foodDataBase.protein.ToString();
        carbohydateNum.text = foodDataBase.carbohydrate.ToString();
        fatNum.text = foodDataBase.fat.ToString();
        vitaminNum.text = foodDataBase.vitamin.ToString();
    }

}
