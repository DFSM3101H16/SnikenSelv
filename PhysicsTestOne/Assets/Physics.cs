using UnityEngine;
using System.Collections;

public class Physics : MonoBehaviour {

	public Vector3 gravity = new Vector3 (0, -9.81f, 0);
	public Vector3 velocity = new Vector3(0,0,0);


	// Use this for initialization
	void Start () 
	{

	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		SetPosition ();
		SetVelocity ();
		SetMaxDistance ();
	}
		
	void SetPosition()
	{
        // s = v0t + 0,5mg^2
		transform.position += (velocity*Time.deltaTime) + (0.5f * gravity * (Time.deltaTime * Time.deltaTime));
	}

	// Increasing velocity for each second, based on acceleration
	void SetVelocity()
	{
		velocity += gravity * Time.deltaTime;
	}

	// Making a fake "ground"
	void SetMaxDistance()
	{
		if (transform.position.y < 0) 
		{
			transform.position = new Vector3 (0, 0, 0);
		}
	}
}

