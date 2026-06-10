using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{


    [SerializeField] float ResDelay = 1f;
    [SerializeField] ParticleSystem crashparticles;
    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerindex = LayerMask.NameToLayer("Floor");
        if (collision.gameObject.layer == layerindex)
        {
            Invoke("ReloadScene",ResDelay);
            crashparticles.Play();
        }
    }
    void ReloadScene()
    {

        SceneManager.LoadScene(0);
    }
}
