using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using Defective.JSON;
public class ServerMaterialDatabase : MaterialDatabase
{
	[SerializeField] string url;
	public override void PrepareDatas()
	{
		StartCoroutine(DowloadMaterialDatabase());
	}
	IEnumerator DowloadMaterialDatabase()
	{
		var webRequest = UnityWebRequest.Get(url);
		yield return webRequest.SendWebRequest();

		var dowloadedText = webRequest.downloadHandler.text;

		var jsonObject = new JSONObject(dowloadedText);

		foreach (var json in jsonObject)
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
