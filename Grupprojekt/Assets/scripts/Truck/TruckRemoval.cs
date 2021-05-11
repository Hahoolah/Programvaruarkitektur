using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckRemoval : MonoBehaviour
{
    float count;
    float countMax;
    MeshRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = this.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
   
    public void DestroyTruck()
    {
        Debug.Log("Removing truck");
        // TODO: Gradually remove truck
    }


   
}


