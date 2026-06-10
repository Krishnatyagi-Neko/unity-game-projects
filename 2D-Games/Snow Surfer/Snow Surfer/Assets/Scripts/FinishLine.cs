using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerindex = LayerMask.NameToLayer("Player");
        if(collision.gameObject.layer == layerindex)
        {
           SceneManager.LoadScene(0);
        }
    }

}
