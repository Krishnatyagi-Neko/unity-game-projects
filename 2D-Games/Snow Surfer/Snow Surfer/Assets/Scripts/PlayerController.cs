using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{   
    
    [SerializeField] float torqueAmount = 1f;
    InputAction moveAction;
    Rigidbody2D myRigidBody2D;
    Vector2 moveVector;
    SurfaceEffector2D surfaceEffector2D;
    [SerializeField] float BaseSpeed = 15f;
    [SerializeField] float BoostSpeed = 200f;


    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        myRigidBody2D = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindFirstObjectByType<SurfaceEffector2D>();
    }

    void FixedUpdate()
    {
        RotatePlayer();
        BoostPlayer();
        
    }

    void RotatePlayer()
    {
        moveVector = moveAction.ReadValue<Vector2>();
        if (moveVector.x < 0)
        {
            myRigidBody2D.AddTorque(torqueAmount);
        }
        else if (moveVector.x > 0)
        {
            myRigidBody2D.AddTorque(-torqueAmount);
        }
    }

    void BoostPlayer()
    {
        if (moveVector.y > 0)
        {
            surfaceEffector2D.speed = BoostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = BaseSpeed;
        }
    }

}