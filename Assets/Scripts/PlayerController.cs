using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
   [SerializeField] float torqueAmount = 1f;  /*this is for player rotation by using torque instead of using 
   transform.Rotate("") */
   [Header("Speed Change When Up Arrow Press")]
   [SerializeField] float baseSpeed = 15f;
   [SerializeField] float boostSpeed = 20f;
   [SerializeField] ParticleSystem powerupParticles;
   [SerializeField] ScoreManager scoreManager;
   
    float previousRotation;
    float totalRotation;
     int activePowerupCount; 

    bool canControlPlayer = true;
   InputAction moveAction;   //create variable for movement 
    Vector2 movementVector;        //create variable which gives left/right/up and down movement
    Rigidbody2D myRigidbody2D; // need this for physics based rotation(torque rotation)
    SurfaceEffector2D surfaceEffector2D;  //refrence take surfaceffector beause it hold speed in this time
   




    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        myRigidbody2D = GetComponent<Rigidbody2D>();   //refrence take 
        surfaceEffector2D = FindAnyObjectByType<SurfaceEffector2D>();
        scoreManager = FindAnyObjectByType<ScoreManager>();
    }
    
    
    // Update is called once per frame
    void Update()
    {
        if(canControlPlayer)
        {
           RotatePlayer();
           BoostPlayer(); 
          CalculateFlips();
        }
       
    }

   void RotatePlayer()
    {
        // Vector2 movementVector; this variable also include in this section but i put above side  
        movementVector = moveAction.ReadValue<Vector2>();


        if(movementVector.x < 0)
        {
            myRigidbody2D.AddTorque(torqueAmount);

        }
        else if(movementVector.x > 0)
        {
            myRigidbody2D.AddTorque(-torqueAmount);
        }
        Debug.Log(movementVector);
    }

    void BoostPlayer()
    {
        if(movementVector.y >0)
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    void CalculateFlips()
    {
        float currentRotation;
        currentRotation = transform.rotation.eulerAngles.z;
        totalRotation += Mathf.DeltaAngle(previousRotation, currentRotation);
        if(totalRotation > 340 || totalRotation < -340)
        {
           
           totalRotation = 0;  
           scoreManager.AddScore(100);   //print(flipCount); replace below code
            
        }
        previousRotation = currentRotation;
    }
    

     public void DisableControl()
    {
        canControlPlayer = false;
    }

    public void ActivatePowerup(PowerupSO powerup)
    {
        powerupParticles.Play();
        activePowerupCount +=1;
     if(powerup.GetPowerupType() == "speed")
        {
            baseSpeed += powerup.GetValueChange();
            boostSpeed += powerup.GetValueChange();
        }   
        else if(powerup.GetPowerupType() == "torque")
        {
            torqueAmount += powerup.GetValueChange();
        }

    }
    public void DeactivatePowerup(PowerupSO powerup) //power-up speed off 
    {
        activePowerupCount -=1;
        if(activePowerupCount == 0)
        {
            powerupParticles.Stop();
        }
        if(powerup.GetPowerupType() == "speed")
        {
           baseSpeed -= powerup.GetValueChange();
        boostSpeed -= powerup.GetValueChange(); 
        }
        else if(powerup.GetPowerupType()== "torque")
        {
            torqueAmount -= powerup.GetValueChange();
        }
        
    }
     


}

