using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FoodDatabase : MonoBehaviour
{
	[SerializeField] public List<FoodData> foodDataList = new List<FoodData>();


	private void Awake()
	{
		PrepareDatas();
	}

	public abstract void PrepareDatas();
}
