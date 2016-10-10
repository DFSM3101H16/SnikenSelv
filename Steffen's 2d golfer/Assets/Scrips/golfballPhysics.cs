using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class golfballPhysics : MonoBehaviour
{

    public Vector3 gravity = new Vector3(0, -9.81f, 0);
    public Vector3 startVelocity;
    public Vector3 dragForce = new Vector3(0, 0, 0);
    public Vector3 accelerationVector;
    public float dragMagnitude;
    public float airDensity = 1.225f;
    public float dragCoefficient = 0.25f;
    public float golfBallSurfaceArea = 0.001432f;
    public float golfBallMass = 0.0459f;
    public ParticleSystem victoryparticle;
    public ParticleSystem retryParticle;
    public bool ballHasStopped;
    public InputField setStartVelocityHere;
    public InputField setDragValueHere;
    public int inputvalue;
    public Button startButton;
    public bool startButtonClicked = false;


    // Use this for initialization
    void Start()
    {
        // setting the particles on pause, for then to start them when the ball hits the ground
            victoryparticle.Pause(); 
            retryParticle.Pause();;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            BallHasStopped();
            Victory();
            calculateBallAcceleration();
            SetVelocity();
            SetPosition();
            SetMaxDistance();       
    }

    void SetPosition()
    {
        // s = v0t + 0,5mg^2
        transform.position += (startVelocity * Time.fixedDeltaTime) + (0.5f * (gravity + accelerationVector) * (Time.fixedDeltaTime * Time.fixedDeltaTime));
    }

    void StopVelocity()
    {
        startVelocity.x = 0;
        startVelocity.y = 0;
        startVelocity.z = 0;
    }

    void BallHasStopped()
    {
        if (startVelocity.x == 0 && startVelocity.y == 0)
        {
            ballHasStopped = true;
        }
        else
        {
            ballHasStopped = false;
        }
    }

    // Increasing startVelocity for each fixedtime, based on acceleration
    void SetVelocity()
    {
        startVelocity += (gravity+accelerationVector)* Time.fixedDeltaTime;
        //gir unøyaktig svar, oulers metode, antar at den deriverte er uendret frem til neste punkt.
    }

    void Victory()
    {
        //Setting partikkelbetingelser for win/loss
        if ((transform.position.x > 4.8f) && transform.position.x < 5.6f)
        {
            victoryparticle.Play();
        }
        else if (!(transform.position.x > 4.8f) && (transform.position.x < 5.6f) && ballHasStopped)
        {
            retryParticle.Play();
        }
    }
    void CalculateDrag()
    {
        //størrelsen av vektoren opphøyd i annen
        //størrelse av luftmotstandvektoren. 
        //luftmotstanden går i motsatt retning av hastigheten
        dragForce = -dragMagnitude * startVelocity.normalized;
        dragMagnitude = (startVelocity.sqrMagnitude * dragCoefficient * golfBallSurfaceArea * airDensity) / 2;
    }
    void calculateBallAcceleration()
    {
        CalculateDrag();
        accelerationVector = dragForce / golfBallMass;
    }

    //Making a fake "ground"
            void SetMaxDistance()
    {
        if (transform.position.y < -1.92)
        {
            transform.position = new Vector3(transform.position.x, -1.92f, 0);
            StopVelocity();
        }
    }
}