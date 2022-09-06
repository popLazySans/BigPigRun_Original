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
		if (sc == 2 && lol == 0) 
		{
			spawn1.SetActive (true);
			spawn2.SetActive (true);
			sound1.SetActive (false);
			sound2.SetActive (true);
			cac.SetActive (true);
			scene1.SetActive (false);
			scene2.SetActive (true);

			SetMaterialColor(249, 255, 50, 20);

			ChangeSpeed(fast, 10);
			ChangeSpeed(slow, 10);

			lol = 1;
		}
		if (sc == 3 && lol == 1) 
		{
			sound2.SetActive (false);
			sound3.SetActive (true);
			scene2.SetActive (false);
			scene3.SetActive (true);
			cac.SetActive (false);

			SetMaterialColor(255, 49, 49, 1);

			ChangeSpeed(fast, -10);
			ChangeSpeed(slow, -10);

			lol = 0;
		}
		if (sc == 4 && lol == 0) 
		{
			sound3.SetActive (false);
			sound4.SetActive (true);
			scene3.SetActive (false);
			scene4.SetActive (true);

			SetMaterialColor(81, 31, 106, 1);

			ChangeSpeed(fast, -5);
			ChangeSpeed(slow, -5);

			cas1.SetActive (false);
			cas2.SetActive (true);
			of.SetActive(true);
			lol = 1;

		}
	}

	void StartGameCoroutine()
	{
		StartCoroutine(SpawnObject());
		StartCoroutine(Fast());
	}

	void SetMaterialColor(byte r, byte g, byte b, byte a)
	{
		col.material.SetColor("_Color", new Color32(r, g, b, a));
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
