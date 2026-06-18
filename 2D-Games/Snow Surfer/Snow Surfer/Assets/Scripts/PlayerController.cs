using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float baseSpeed = 15f;
    [SerializeField] float boostSpeed = 20f;

    InputAction moveAction;
    Rigidbody2D myRigidbody2D;
    SurfaceEffector2D surfaceEffector2D;

    Vector2 moveVector;
    bool canControlPlayer = true;
    float previousRotation;
    float totalRotation;

    ScoreManager scoreManager;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        myRigidbody2D = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindFirstObjectByType<SurfaceEffector2D>();
        scoreManager = FindAnyObjectByType<ScoreManager>();
    }

    void Update()
    {
        if (canControlPlayer)
        {
            RotatePlayer();
            BoostPlayer();
            CalculateFlips();   
        }
    }

    void RotatePlayer()
    {
        moveVector = moveAction.ReadValue<Vector2>();
        if (moveVector.x < 0)
        {
            myRigidbody2D.AddTorque(torqueAmount);
        }
        else if (moveVector.x > 0)
        {
            myRigidbody2D.AddTorque(-torqueAmount);
        }
    }

    void BoostPlayer()
    {
        if (moveVector.y > 0)
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
    float currentRotation = transform.rotation.eulerAngles.z;
    
    totalRotation += Mathf.DeltaAngle(previousRotation, currentRotation);

    if (totalRotation > 340 || totalRotation < -340)
    {
        totalRotation = 0;
        scoreManager.AddScore(100);
    }

    previousRotation = currentRotation;
}

    public void DisableControls()
    {
        canControlPlayer = false;
    }

    public void ActivatePowerup(PowerupSO powerup)
    {
        if(powerup.GetPowerType() == "speed")
        {
            baseSpeed += powerup.GetValueChange();
            boostSpeed += powerup.GetValueChange();
        }

        else if(powerup.GetPowerType() == "torque")
        {
            torqueAmount += powerup.GetValueChange();
        }
        
    }


    public void DeactivatePowerup(PowerupSO powerup)
    {
         if(powerup.GetPowerType() == "speed")
        {
            baseSpeed -= powerup.GetValueChange();
            boostSpeed -= powerup.GetValueChange();
        }

        else if(powerup.GetPowerType() == "torque")
        {
            torqueAmount -= powerup.GetValueChange();
        }
    }
}