using UnityEngine;

public class SnowTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem snowparticles;
    int layerIndex; // No initialization here

    void Awake()
    {
        layerIndex = LayerMask.NameToLayer("Floor"); // Safe here
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == layerIndex)
        {
            snowparticles.Play();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == layerIndex)
        {
            snowparticles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
    }
}