using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D myRigidBody;
    [SerializeField] float movespeed = 5f;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Run();
    }

    void OnMove(InputValue value)
    {
        
        moveInput = value.Get<Vector2>();
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x*movespeed, myRigidBody.linearVelocity.y);
        myRigidBody.linearVelocity = playerVelocity;
    }
    




}
