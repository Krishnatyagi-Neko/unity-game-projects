using TreeEditor;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    
    public GameObject pipe;
    public float spawnRate = 1;
    private float timer =0;
    public float heightOffset = 7;
    void Start()
    {
        spawnPipe();
    }

    void Update()
    {
        if (timer<spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer=0;
        }
    }
 void spawnPipe()
        {
            float lowestpoint = transform.position.y - heightOffset;
            float highestpoint = transform.position.y + heightOffset;
            Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestpoint,highestpoint),0), transform.rotation);
        }
}
