using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class AutoObjectSpawnerLock : MonoBehaviour
{
	public float slow;
	public float fast;
	public int time;
	public int timer;
	public int rate;
	public static int die;
	public GameObject warn;
	public int warni = 1;
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
		 
			StartCoroutine(SpawnObject());
			StartCoroutine (Fast ());

	}
	void Update()
	{

	}
	
	// This will spawn an object, and then wait some time, then spawn another...
	IEnumerator SpawnObject ()
	{
		yield return new WaitForSeconds (rate);
			while (true) {
				
					// Create some random numbers
			yield return new WaitForSeconds (fast);
					
					// Generate the new object
					GameObject newObject = Instantiate<GameObject> (prefabToSpawn);
					newObject.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);
					die = 1;
					StartCoroutine (Warn ());
					yield return new WaitForSeconds (15f);
					fast += 10;
					Destroy (newObject);
					
					// Wait for some time before spawning another object
				

		}
	}
	IEnumerator Fast()
	{
		yield return new WaitForSeconds (timer);
		time = 1;
	}
	IEnumerator Warn()
	{
		while (true) 
		{
			if (warni % 2 == 1) 
			{
				warn.SetActive (true);
			}
			if (warni % 2 == 0) {
				warn.SetActive (false);
			}
			warni += 1;
			yield return new WaitForSeconds (0.5f);
			if (warni == 11) 
			{
				warni = 1;
				break;
			}
		}
	}

}
