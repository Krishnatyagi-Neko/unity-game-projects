using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class Rider : MonoBehaviour
{

    [SerializeField] float currentSpeed = 5f;
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float boostSpeed = 10f;
    [SerializeField] float regularSpeed = 5f;

    [SerializeField]TMP_Text boosttext;
    [SerializeField] float delayTime = 1f;

    void Start()
    {
    boosttext.gameObject.SetActive(false);
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boost"))
        {
            currentSpeed = boostSpeed;
            boosttext.gameObject.SetActive(true);
            Destroy(collision.gameObject,0.1f*delayTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        boosttext.gameObject.SetActive(false);
        currentSpeed = regularSpeed;
    }

    void Update()
    {
        
        float move = 0f;
        float steer = 0f;
        

        if (Keyboard.current.wKey.isPressed)
        {
            move = 1f;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            move = -1f;
        }

        if (Keyboard.current.aKey.isPressed)
        {
            steer = 1f;
        }

        if (Keyboard.current.dKey.isPressed)
        {
            steer = -1f;
        }

        float moveAmount = move*currentSpeed*Time.deltaTime;
        float steerAmount = steer*steerSpeed*Time.deltaTime;
        
        transform.Translate(0,moveAmount,0);
        transform.Rotate(0,0,steerAmount);
    
    }
}
