using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTruck : MonoBehaviour
{
    int spawned;
    float count;
    [SerializeField]
    public GameObject truck;
    public float spawnSeconds;
    public int timesToSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(spawned < timesToSpawn)
        {
            if (count < spawnSeconds)
            {
                count += Time.deltaTime;
            }
            else
            {
                spawn();
                count = 0;
                spawned++;
            }
        }
        else
        {
            Destroy(this);
        }
        
        
    }

    private void spawn()
    {
        Instantiate(truck, this.transform.position, this.transform.rotation);
    }
}
