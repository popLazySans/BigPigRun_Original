using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class AutoObjectSpawnerTest : MonoBehaviour
{
	public float slow;
	public float fast;
	public int time;
	public int timer;
	public int rate;
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
		 
			StartCoroutine(SpawnObjectRoutine());
			StartCoroutine (Fast ());

	}
	void Update()
	{

	}
	
	// This will spawn an object, and then wait some time, then spawn another...
	IEnumerator SpawnObjectRoutine ()
	{
		yield return new WaitForSeconds (rate);
			while (true) {
				
					// Create some random numbers
			yield return new WaitForSeconds (fast);
					
					// Generate the new object
					GameObject newObject = Instantiate<GameObject> (prefabToSpawn);
					newObject.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);
					yield return new WaitForSeconds (15f);
					Destroy (newObject);
					
					// Wait for some time before spawning another object
				

		}
	}
	IEnumerator Fast()
	{
		yield return new WaitForSeconds (timer);
		time = 1;
	}

}
