using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
	[SerializeField]
	private float moveSpeed = 10f;
	[SerializeField]
	private float steerSpeed = 180f;
	
	[SerializeField]
	float slowSpeed = 5f;
	[SerializeField]
	float fastSpeed = 15f;



	void Update()
	{
		float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
		float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

		transform.Rotate(0, 0, -steerAmount);
		transform.Translate(0, moveAmount , 0);
		
		if (Input.GetKeyDown("escape"))
		
		{
			Application.Quit();
		} 
	}
	
	private void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.tag == "Boost")
		
		{
			moveSpeed = fastSpeed;
			Destroy(other.gameObject);
		}
		
		if (other.tag == "Bump")
		
		{
			moveSpeed = slowSpeed;
			Destroy(other.gameObject);
		}
	}
}
