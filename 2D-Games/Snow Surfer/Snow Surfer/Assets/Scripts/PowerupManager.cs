using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    [SerializeField] PowerupSO powerup;

    PlayerController player;
    SpriteRenderer spriteRenderer;
    float timeleft;

    void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        timeleft = powerup.GetTime();
    }

    void Update()
    {
      CountdownTimer();
    }

    void CountdownTimer()
    {
          if(spriteRenderer.enabled == false)
        {
            if (timeleft > 0) 
            {
                timeleft  -= Time.deltaTime;
                if(timeleft <= 0)
                {
                   player.DeactivatePowerup(powerup);
                }
                
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerindex = LayerMask.NameToLayer("Player");
        if(collision.gameObject.layer == layerindex && spriteRenderer.enabled)
        {
            spriteRenderer.enabled = false;
            player.ActivatePowerup(powerup);
        }
    }


}
