using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class SceneLevelManager : MonoBehaviour
{
	
	public Renderer sphereColor;
	public GameObject defaultCastle;
	public GameObject corruptCastle;
	public GameObject specialEnemySpawner;
	public GameObject cactusSpawner;
	public GameObject defaultScene;
	public GameObject desertScene;
	public GameObject crimsonScene;
	public GameObject corruptScene;
	public GameObject defaultSound;
	public GameObject desertSound;
	public GameObject crimsonSound;
	public GameObject corruptSound;
	public static int currentScene;
	public SpawnObjectManager spawnObjectFunction;

	[SerializeField] MaterialDatabase materialDatabase;

	void Update()
	{
		currentScene = WaveAndStage.stage;
		CheckSceneCondition();
	}

	public void CheckSceneCondition()
	{
		CheckDesertCondition();
		CheckCrimsonCondition();
		CheckCorruptCondition();
	}

	public void CheckDesertCondition()
	{
		if (currentScene == 2)
		{
			SetDesertScene();
			spawnObjectFunction.SetActiveSpawn();
			spawnObjectFunction.ChangeCurrentSpeed(10);
		}
	}

	public void CheckCrimsonCondition()
	{
		if (currentScene == 3)
		{
			SetCrimsonScene();
			spawnObjectFunction.ChangeCurrentSpeed(-10);
		}
	}

	public void CheckCorruptCondition()
	{
		if (currentScene == 4)
		{
			SetCorruptScene();
			spawnObjectFunction.ChangeCurrentSpeed(-5);
			specialEnemySpawner.SetActive(true);
		}
	}

	public void SetDesertScene()
	{
		ChangeActiveGameObject(defaultSound, desertSound);
		ChangeActiveGameObject(defaultScene, desertScene);
		cactusSpawner.SetActive(true);
		SetMaterialColor(materialDatabase.materialDataList[0]);
	}

	public void SetCrimsonScene()
	{
		ChangeActiveGameObject(desertSound, crimsonSound);
		ChangeActiveGameObject(desertScene, crimsonScene );
		cactusSpawner.SetActive(false);
		SetMaterialColor(materialDatabase.materialDataList[1]);
	}

	public void SetCorruptScene()
	{
		ChangeActiveGameObject(crimsonSound, corruptSound);
		ChangeActiveGameObject(crimsonScene, corruptScene);
		ChangeActiveGameObject(defaultCastle, corruptCastle);
		SetMaterialColor(materialDatabase.materialDataList[2]);
	}

	public void ChangeActiveGameObject(GameObject currentGameObject, GameObject newGameObject)
	{
		currentGameObject.SetActive(false);
		newGameObject.SetActive(true);
	}

	public void SetMaterialColor(MaterialData materialDatabase)
	{
		sphereColor.material.SetColor("_Color", new Color32((byte)materialDatabase.r, (byte)materialDatabase.g, (byte)materialDatabase.b, (byte)materialDatabase.a));
	}



}
