using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float movespeed = 5;
    public float deadZone = -45;
    void Start()
    {
        
    }
    void Update()
    {
        transform.position = transform.position + (Vector3.left*movespeed) * Time.deltaTime;

        if(transform.position.x<deadZone)
        {
            Debug.Log("Pipe Deleted");
            Destroy(gameObject);
        }
    }
}
