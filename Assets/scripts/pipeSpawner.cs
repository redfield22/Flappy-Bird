using Unity.VisualScripting;
using UnityEngine;

public class pipeSpawner : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2;
    private float Timer = 0;
    public float HeightOffset;
    public bool move = false;
    void Start()
    {
        print("work");
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer < spawnRate)
        {
            Timer = Timer + Time.deltaTime;
        }
        else
        {
            SpawnPipe();
            Timer = 0;
        }
  
            
    }
    void SpawnPipe()
    {
        float lowestpoint = transform.position.y - HeightOffset;
        float highestpoint = transform.position.y + HeightOffset;
        print(lowestpoint + " " + highestpoint+"\n");
        float randomy = Random.Range(lowestpoint, highestpoint);
        print("pos"+ randomy);
        Instantiate(pipe, new Vector3(transform.position.x,randomy,0) , transform.rotation);
    }
}
