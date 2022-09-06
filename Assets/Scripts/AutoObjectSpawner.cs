using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class AutoObjectSpawner : MonoBehaviour
{
	public float slow;
	public float fast;
	public int time;
	public int timer;
	public int rate;
	public static int sc;
	public int lol;
	public Renderer col;
	public GameObject cas1;
	public GameObject cas2;
	public GameObject of;
	public GameObject cac;
	public GameObject scene1;
	public GameObject scene2;
	public GameObject scene3;
	public GameObject scene4;
	public GameObject sound1;
	public GameObject sound2;
	public GameObject sound3;
	public GameObject sound4;
	public GameObject spawn1;
	public GameObject spawn2;
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
		sc = PlayerSuvive.sc;
		CheckDesertCondition();
		CheckCrimsonCondition();
		CheckCorruptCondition();
	}

	void StartGameCoroutine()
	{
		StartCoroutine(SpawnObject());
		StartCoroutine(Fast());
	}

	void CheckDesertCondition()
	{
		if (sc == 2 && lol == 0)
		{
			SetActiveSpawn();
			SetDesertScene();
			ChangeCurrentSpeedByFloat(10);
			lol = 1;
		}
	}

	void CheckCrimsonCondition()
	{
		if (sc == 3 && lol == 1)
		{
			SetCrimsonScene();
			ChangeCurrentSpeedByFloat(-10);
			lol = 0;
		}
	}

	void CheckCorruptCondition()
	{
		if (sc == 4 && lol == 0)
		{
			SetCorruptScene();
			ChangeCurrentSpeedByFloat(-5);
			of.SetActive(true);
			lol = 1;
		}
	}

	void SetDesertScene()
	{
		ChangeActiveGameObject(sound1, sound2);
		ChangeActiveGameObject(scene1, scene2);
		cac.SetActive(true);
		SetMaterialColor(249, 255, 50, 20);
	}

	void SetCrimsonScene()
	{
		ChangeActiveGameObject(sound2, sound3);
		cac.SetActive(false);
		SetMaterialColor(255, 49, 49, 1);
	}

	void SetCorruptScene()
	{
		ChangeActiveGameObject(sound3, sound4);
		ChangeActiveGameObject(scene3, scene4);
		ChangeActiveGameObject(cas1, cas2);
		SetMaterialColor(81, 31, 106, 1);
	}

	void SetActiveSpawn()
	{
		spawn1.SetActive(true);
		spawn2.SetActive(true);
	}

	void ChangeActiveGameObject(GameObject currentGameObject, GameObject newGameObject)
	{
		currentGameObject.SetActive(false);
		currentGameObject.SetActive(true);
	}

	void SetMaterialColor(byte r, byte g, byte b, byte a)
	{
		col.material.SetColor("_Color", new Color32(r, g, b, a));
	}

	void ChangeCurrentSpeedByFloat(float speed)
	{
		ChangeSpeed(fast, speed);
		ChangeSpeed(slow, speed);
	}

	float ChangeSpeed(float currentSpeed ,float speed)
	{
		float newSpeed= currentSpeed + speed;
		return newSpeed;
	}

	// This will spawn an object, and then wait some time, then spawn another...
	IEnumerator SpawnObject ()
	{
		yield return new WaitForSeconds (rate);
			while (true) {
				
					// Create some random numbers
					yield return new WaitForSeconds (Random.Range (fast, slow));
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
		yield return new WaitForSeconds (timer);
		time = 1;
	}

}
