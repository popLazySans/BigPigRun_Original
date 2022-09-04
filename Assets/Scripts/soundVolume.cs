using UnityEngine;
using System.Collections;

public class soundVolume : MonoBehaviour {
	public int MaxHealth;
	public TextMesh CoresGui;
	public int health;
	public AudioSettings set;
	public GameObject particle;
	public GameObject Cube;
	public GameObject Smoke;
	private bool hassmoke = false;
	public AudioClip play;

	void Awake(){
		health = MaxHealth;
	}

	public void ReceiveDamage(int damage){
		health -= damage;
		GameObject part = (GameObject)Instantiate (particle, Cube.transform.position, Cube.transform.rotation);
		AudioSource.PlayClipAtPoint (play,transform.position,10f); //audio
		Destroy (part, 1f);
	}

	void Update(){

		if (health <= 0)
			Application.LoadLevel (2);
		if (health == 30 && hassmoke == false) {
			Instantiate (Smoke, Cube.transform.position, Cube.transform.rotation);
			hassmoke = true;
		}
	}
}