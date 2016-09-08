using UnityEngine;
using System.Collections;

public class Friction : MonoBehaviour {

    public Vector3 kineticFriction;
    public Vector3 staticFriction;
    public Vector3 friction;
    public float massOfObject;
    public Vector3 force;
    public Vector3 gravity = new Vector3(0, -9.81f, 0);
    public Vector3 velocity = new Vector3(0, 0, 0);


    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        CheckIfBoxMoves();
	}

    public void CheckIfBoxMoves()
    {
        if(((staticFriction.magnitude > force.magnitude) || (kineticFriction.magnitude> force.magnitude)) && (velocity.x != 0))
        {
            velocity.x = 0;
        }
        else
        {
            SetVelocity();
        }
    }

    void SetPosition()
    {
        transform.position += (velocity * Time.deltaTime) + (0.5f * gravity * (Time.deltaTime * Time.deltaTime));
    }

    // Increasing velocity for each second, based on acceleration
    void SetVelocity()
    {
        velocity -= kineticFriction * Time.deltaTime;
    }
    void CalculateForce()
    {
        force = massOfObject * gravity;
    }
    void CalculateFriction()
    {
    }

}
