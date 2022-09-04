using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Done_list{
	public float minX,maxX,minY,maxY,minZ,maxZ;
}
public class PlayerMovementScript : MonoBehaviour {

	public static float pot;
	public static int oil;
	public float point;
	public int lio;
    public float moveSpeed;
	public KeyCode Jump;
    private Vector3 moveDirection;
	public Done_list list;
	void Start()
	{

	}
    void Update()
    {
		point = pot;
		lio = oil;
		if (point <= 500) {
			point = 501;
		} else {
			point = pot;
		}

    }

    void FixedUpdate()
    {
		float moveX = Input.GetAxisRaw ("Horizontal");
		float moveZ = Input.GetAxisRaw ("Vertical");
		moveDirection = new Vector3(moveX, 0, moveZ).normalized;

		GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection) * (((moveSpeed)*1000/(1+point)) - oil/50) * Time.deltaTime);
		GetComponent<Rigidbody>().position = new Vector3
			(
				Mathf.Clamp (GetComponent<Rigidbody>().position.x, list.minX, list.maxX), 
				Mathf.Clamp (GetComponent<Rigidbody>().position.y, list.minY, list.maxY) 
				,Mathf.Clamp (GetComponent<Rigidbody>().position.z, list.minZ, list.maxZ)
			);
    }
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Cactus") 
		{
			moveSpeed = 0;
			StartCoroutine (wait ());
		}
	}
	IEnumerator wait()
	{
		yield return new WaitForSeconds (3);
		moveSpeed += 2;
	}
}
