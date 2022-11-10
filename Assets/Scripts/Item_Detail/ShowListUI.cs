using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ShowListUI : MonoBehaviour
{
    [SerializeField] Text MaxEnergyText;
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

        MaxEnergyText.text = "Max Energy : " + foodDatabase.foodDataList.Max(itemData => itemData.energy);
    }

    void AddFoodListUI(ShowFoodList foodListPrefab)
	{
        foodLists.Add(foodListPrefab);

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
            AddFoodListUI(foodUI);
        }
    }

    public void SortByLowestEnergy()
    {
        List<FoodData> sortedFoodItemDatas = foodDatabase.foodDataList.OrderBy(itemData => itemData.energy).ToList();
        foodDatabase.foodDataList = sortedFoodItemDatas;
		SetupUI(foodDatabase);

	}

	public void SortByHightestEnergy()
    {
        List<FoodData> sortedFoodItemDatas = foodDatabase.foodDataList.OrderByDescending(itemData => itemData.energy).ToList();
        foodDatabase.foodDataList = sortedFoodItemDatas;
        SetupUI(foodDatabase);
    }

    public void SortByAToZ()
    {
        List<FoodData> sortedFoodItemDatas = foodDatabase.foodDataList.OrderBy(itemData => itemData.name).ToList();
        foodDatabase.foodDataList = sortedFoodItemDatas;
        SetupUI(foodDatabase);
    }

    public void FilterVitaminOnly()
	{
        List<FoodData> sortedFoodItemDatas = foodDatabase.foodDataList.Where(itemData => itemData.vitamin != 0).ToList();
        foodDatabase.foodDataList = sortedFoodItemDatas;
        SetupUI(foodDatabase);
    }
}
