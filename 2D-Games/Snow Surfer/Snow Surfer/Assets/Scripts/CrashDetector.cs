using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerindex = LayerMask.NameToLayer("Floor");
        if (collision.gameObject.layer == layerindex)
        {
            Invoke("ReloadSceneCrash",1f);
        }
    }
    void ReloadSceneCrash()
    {
        SceneManager.LoadScene(0);
    }
}
