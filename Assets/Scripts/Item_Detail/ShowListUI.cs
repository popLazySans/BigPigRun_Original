using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowListUI : MonoBehaviour
{
    [SerializeField] Transform foodListParent;
    [SerializeField] ShowFoodList foodListPrefab;
    [SerializeField] List<ShowFoodList> foodLists = new List<ShowFoodList>();
    [SerializeField] FoodDatabase foodDatabase;


    void Start()
    {
        foodListPrefab.gameObject.SetActive(false);
        SetupUI(foodDatabase);
    }

	void SetupUI(FoodDatabase foodDatabase)
	{
        DestroyAndClearAllUIs();
        CreateUIs(foodDatabase);
    }

    void DestroyAndClearAllUIs()
    {
        foreach (var ui in foodLists)
            Destroy(ui.gameObject);

        foodLists.Clear();
    }

    void CreateUIs(FoodDatabase datas)
    {
        for (int i = 0; i < foodDatabase.foodDataList.Count; i++) 
		{
            var foodUI = Instantiate(foodListPrefab, foodListParent, false);
            foodUI.gameObject.SetActive(true);
            foodUI.SetFoodData(foodDatabase.foodDataList[i]);

        }
    }
}
