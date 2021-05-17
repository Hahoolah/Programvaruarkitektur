using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTruckDetection : MonoBehaviour
{
    private int spawned;
    [SerializeField]
    public GameObject truck;
    public GameObject effect;
    public LevelLogicManager logicManager;
    private bool startSpawning = false;
    float count;
    public float spawnSeconds;
    public int timesToSpawn; // if 0 spawn infinite
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        logicManager = GameObject.FindGameObjectWithTag("LevelLogicManager").GetComponent<LevelLogicManager>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startSpawning)
        {
            if (spawned < timesToSpawn || timesToSpawn == 0)
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
        }

        if (Vector3.Distance(gameObject.transform.position, playerTransform.position) > 2000)
        {
            startSpawning = false;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            spawn();
            startSpawning = true;

        }
    }



    private void spawn()
    {
        if (truck != null)
        {
            Instantiate(effect, new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z), this.transform.rotation);
            Instantiate(truck, this.transform.position, this.transform.rotation);
        }
        
    }
}
