using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Defective.JSON;
using UnityEngine;

public class LocalFoodDatabase : FoodDatabase
{
	[SerializeField] TextAsset jsonFile;

	public override void PrepareDatas()
	{
		var jsonObject = new JSONObject(jsonFile.text);

		foreach (var json in jsonObject)
		{
			var foodName = "";
			json.GetField(ref foodName, "name");

			var Energy = 0;
			json.GetField(ref Energy, "energy");

			var Protein = 0;
			json.GetField(ref Protein, "protein");

			var Carbohydrate = 0;
			json.GetField(ref Carbohydrate, "carbohydrate");

			var Fat = 0;
			json.GetField(ref Fat, "fat");

			var Vitamin = 0;
			json.GetField(ref Vitamin, "vitamin");

			var newFoodData = new FoodData();
			newFoodData.name = foodName;
			newFoodData.energy = Energy;
			newFoodData.protein = Protein;
			newFoodData.carbohydrate = Carbohydrate;
			newFoodData.fat = Fat;
			newFoodData.vitamin = Vitamin;

			foodDataList.Add(newFoodData);
		}

	}
}
