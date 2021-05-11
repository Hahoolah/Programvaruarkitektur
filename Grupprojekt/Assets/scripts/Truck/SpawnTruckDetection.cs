using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTruckDetection : MonoBehaviour
{
    private bool spawned;
    [SerializeField]
    public GameObject truck;
    public GameObject effect;
    public LevelLogicManager logicManager;

    // Start is called before the first frame update
    void Start()
    {
        logicManager = GameObject.FindGameObjectWithTag("LevelLogicManager").GetComponent<LevelLogicManager>();
    }

    // Update is called once per frame
    void Update()
    {    
            
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Spawn");
            spawn();

        }
    }



    private void spawn()
    {
        Instantiate(effect, new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z), this.transform.rotation);
        Instantiate(truck, this.transform.position, this.transform.rotation);
    }
}
