using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{


    [SerializeField] float ResDelay = 1f;    
    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerindex = LayerMask.NameToLayer("Floor");
        if (collision.gameObject.layer == layerindex)
        {
            Invoke("ReloadScene",ResDelay);
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
