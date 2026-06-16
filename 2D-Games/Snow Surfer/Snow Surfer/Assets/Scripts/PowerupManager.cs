using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    [SerializeField] PowerupSO powerup;

    PlayerController player;

    void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerindex = LayerMask.NameToLayer("Player");
        if(collision.gameObject.layer == layerindex)
        {
        player.ActivatePowerup(powerup);
        }
    }



}
