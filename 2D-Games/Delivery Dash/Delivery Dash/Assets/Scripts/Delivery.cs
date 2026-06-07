using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;
    [SerializeField] float delayTime = 1f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Package") && !hasPackage)
        {
            Debug.Log("Picked Up a PACKAGE");
            hasPackage = true;
            GetComponent<ParticleSystem>().Play();
            Destroy(collision.gameObject, 0.5f * delayTime);
        }

        if (collision.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("Package Delivered To Customer");
            hasPackage = false;
            GetComponent<ParticleSystem>().Stop();
            Destroy(collision.gameObject,0.1f*delayTime);
        }
    }
}