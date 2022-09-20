using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

public class SpawnObjectManager : MonoBehaviour
{
	public float slowSpeed;
	public float fastSpeed;
	public int spawnRate;
	public GameObject foodSpawner;

	[Header("Object creation")]
	public GameObject prefabToSpawn;

	[Header("Other options")]
	public float spawnInterval = 1f;

	private BoxCollider boxCollider2D;

	void Start()
	{
		boxCollider2D = GetComponent<BoxCollider>();
		StartGameCoroutine();
	}

	public void StartGameCoroutine()
	{
		StartCoroutine(SpawnObject());
		StartCoroutine(Fast());
	}

	public void SetActiveSpawn()
    {
        foodSpawner.SetActive(true);
    }

	public void ChangeCurrentSpeed(float speed)
	{
		ChangeSpeed(fastSpeed, speed);
		ChangeSpeed(slowSpeed, speed);
	}

	public float ChangeSpeed(float currentSpeed, float speed)
	{
		float newSpeed = currentSpeed + speed;
		return newSpeed;
	}

	IEnumerator SpawnObject()
	{
		yield return new WaitForSeconds(spawnRate);
		while (true)
		{
			yield return new WaitForSeconds(Random.Range(fastSpeed, slowSpeed));
			GameObject newObject = GenerateNewObject();
			yield return new WaitForSeconds(10f);
			Destroy(newObject);
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
		yield return new WaitForSeconds(spawnInterval);
	}

}

