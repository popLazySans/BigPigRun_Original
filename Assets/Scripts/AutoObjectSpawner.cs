using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class AutoObjectSpawner : MonoBehaviour
{
	public float slowSpeed;
	public float fastSpeed;
	public int spawnRate;
	public static int currentScene;
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
	public GameObject foodSpawner;
	[Header("Object creation")]

	// The object to spawn
	// WARNING: take if from the Project panel, NOT the Scene/Hierarchy!
	public GameObject prefabToSpawn;

	[Header("Other options")]

	// Configure the spawning pattern
	public float spawnInterval = 1f;

	private BoxCollider boxCollider2D;

	void Start ()
	{
		boxCollider2D = GetComponent<BoxCollider>();
		StartGameCoroutine();
	}
	void Update()
	{
		currentScene = PlayerSuvive.sc;
		CheckSceneCondition();
	}

	void StartGameCoroutine()
	{
		StartCoroutine(SpawnObject());
		StartCoroutine(Fast());
	}

	void CheckSceneCondition()
	{
		CheckDesertCondition();
		CheckCrimsonCondition();
		CheckCorruptCondition();
	}

	void CheckDesertCondition()
	{
		if (currentScene == 2)
		{
			SetActiveSpawn();
			SetDesertScene();
			ChangeCurrentSpeed(10);
		}
	}

	void CheckCrimsonCondition()
	{
		if (currentScene == 3)
		{
			SetCrimsonScene();
			ChangeCurrentSpeed(-10);
		}
	}

	void CheckCorruptCondition()
	{
		if (currentScene == 4)
		{
			SetCorruptScene();
			ChangeCurrentSpeed(-5);
			specialEnemySpawner.SetActive(true);
		}
	}

	void SetDesertScene()
	{
		ChangeActiveGameObject(defaultSound, desertSound);
		ChangeActiveGameObject(defaultScene, desertScene);
		cactusSpawner.SetActive(true);
		SetMaterialColor(249, 255, 50, 20);
	}

	void SetCrimsonScene()
	{
		ChangeActiveGameObject(desertSound, crimsonSound);
		cactusSpawner.SetActive(false);
		SetMaterialColor(255, 49, 49, 1);
	}

	void SetCorruptScene()
	{
		ChangeActiveGameObject(crimsonSound, corruptSound);
		ChangeActiveGameObject(crimsonScene, corruptScene);
		ChangeActiveGameObject(defaultCastle, corruptCastle);
		SetMaterialColor(81, 31, 106, 1);
	}

	void SetActiveSpawn()
	{
		foodSpawner.SetActive(true);
	}

	void ChangeActiveGameObject(GameObject currentGameObject, GameObject newGameObject)
	{
		currentGameObject.SetActive(false);
		newGameObject.SetActive(true);
	}

	void SetMaterialColor(byte r, byte g, byte b, byte a)
	{
		sphereColor.material.SetColor("_Color", new Color32(r, g, b, a));
	}

	void ChangeCurrentSpeed(float speed)
	{
		ChangeSpeed(fastSpeed, speed);
		ChangeSpeed(slowSpeed, speed);
	}

	float ChangeSpeed(float currentSpeed ,float speed)
	{
		float newSpeed= currentSpeed + speed;
		return newSpeed;
	}

	// This will spawn an object, and then wait some time, then spawn another...
	IEnumerator SpawnObject ()
	{
		yield return new WaitForSeconds (spawnRate);
			while (true) {
				
					// Create some random numbers
					yield return new WaitForSeconds (Random.Range (fastSpeed, slowSpeed));
					// Generate the new object
					GameObject newObject = GenerateNewObject();
					yield return new WaitForSeconds (10f);
					Destroy (newObject);
					// Wait for some time before spawning another object
		}
	}

	GameObject GenerateNewObject()
	{
		GameObject newObject = Instantiate<GameObject>(prefabToSpawn);
		newObject.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
		return newObject;
	}

	IEnumerator Fast()
	{
		yield return new WaitForSeconds (spawnInterval);
	}

}
