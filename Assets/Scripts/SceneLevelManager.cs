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
		SetMaterialColor(249, 255, 50, 20);
	}

	public void SetCrimsonScene()
	{
		ChangeActiveGameObject(desertSound, crimsonSound);
		ChangeActiveGameObject(desertScene, crimsonScene );
		cactusSpawner.SetActive(false);
		SetMaterialColor(255, 49, 49, 1);
	}

	public void SetCorruptScene()
	{
		ChangeActiveGameObject(crimsonSound, corruptSound);
		ChangeActiveGameObject(crimsonScene, corruptScene);
		ChangeActiveGameObject(defaultCastle, corruptCastle);
		SetMaterialColor(81, 31, 106, 1);
	}

	public void ChangeActiveGameObject(GameObject currentGameObject, GameObject newGameObject)
	{
		currentGameObject.SetActive(false);
		newGameObject.SetActive(true);
	}

	public void SetMaterialColor(int r, int g, int b, int a)
	{
		sphereColor.material.SetColor("_Color", new Color32((byte)r, (byte)g, (byte)b, (byte)a));
	}



}
