using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTruck : MonoBehaviour
{
    int spawned;
    float count;
    [SerializeField]
    public GameObject truck;
    public GameObject effect;
    public float spawnSeconds;
    public int timesToSpawn; // if 0 spawn infinite
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(spawned < timesToSpawn || timesToSpawn == 0)
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
        Instantiate(effect, new Vector3(this.transform.position.x + 1,this.transform.position.y, this.transform.position.z), this.transform.rotation);
        Instantiate(truck, this.transform.position, this.transform.rotation);
    }
}
