using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    InputAction moveAction;
    Vector3 moveVector;

    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float leftBoundPadding;
    [SerializeField] float rightBoundPadding;

    Vector2 minBounds;
    Vector2 maxBounds;


    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        MovePlayer();
    }

    void IninBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }


    void MovePlayer()
    {
        moveVector = moveAction.ReadValue<Vector2>();
        Vector3 newPos = transform.position + moveVector * moveSpeed * Time.deltaTime;
        
        newPos.x = math.clamp(newPos.x ,minBounds.x + leftBoundPadding , maxBounds.x + rightBoundPadding);
        newPos.y = math.clamp(newPos.y ,minBounds.y , maxBounds.y);

        transform.position = newPos;

    }


}
