using UnityEngine;

public class CoinPickup : MonoBehaviour
{

    [SerializeField] AudioClip CoinPickupSFX;

    bool wasCollected = false;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !wasCollected)
        {
            wasCollected = true;
            AudioSource.PlayClipAtPoint(CoinPickupSFX, transform.position);
            Destroy(gameObject);
        }
    }
}
