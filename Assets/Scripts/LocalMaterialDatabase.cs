using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Defective.JSON;
using UnityEngine;

public class LocalMaterialDatabase : MaterialDatabase
{
	[SerializeField] TextAsset jsonFile;

	public override void PrepareDatas()
	{
		var jsonObject = new JSONObject(jsonFile.text);

		foreach(var json in jsonObject)
		{
			var sceneName = "";
			json.GetField(ref sceneName, "scene");

			var R = 0;
			json.GetField(ref R, "r");

			var G = 0;
			json.GetField(ref G, "g");

			var B = 0;
			json.GetField(ref B, "b");

			var A = 0;
			json.GetField(ref A, "a");


			var newMaterialData = new MaterialData();
			newMaterialData.name = sceneName;
			newMaterialData.r = R;
			newMaterialData.g = G;
			newMaterialData.b = B;
			newMaterialData.a = A;

			materialDataList.Add(newMaterialData);
		}

	}
}
