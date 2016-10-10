using UnityEngine;
using System.Collections;

public class ParashooterPhysics : MonoBehaviour {

    public int personMass = 85;
    public float radius;
    public float velocity;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void ReleaseParashoot()
    {
       // radius =  
    }
    public void runge_kutta4(float y_n, float t_n, float h)
    {
        float k1 = Function(t_n, y_n);
        float k2 = Function(t_n + h / 2, y_n + (h / 2) * k1);
        float k3 = Function(t_n + h / 2, y_n + (h / 2) * k2);
 
    }
    public float Function(float t, float y)
    {
        return (t * y);
    }
    public void ParashootControll()
    {
        if (Input.GetButtonDown("A"))
        {

            ReleaseParashoot();
        }
        else
        {
        }
    }
}
