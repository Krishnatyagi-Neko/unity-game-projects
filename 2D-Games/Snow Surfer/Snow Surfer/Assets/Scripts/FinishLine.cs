using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float ResDelay = 1f;
    [SerializeField] ParticleSystem finishparticles;
    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerindex = LayerMask.NameToLayer("Player");
        if(collision.gameObject.layer == layerindex)
        {
            Invoke("ReloadScene",ResDelay);
            finishparticles.Play();
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

}
