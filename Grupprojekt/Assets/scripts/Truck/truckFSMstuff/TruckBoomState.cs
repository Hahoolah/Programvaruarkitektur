using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckBoomState : INPCState
{
    float sinX;
    public INPCState DoState(TruckFSM truck)
    {
        DoBoom(truck);
        return truck.truckBoomState; 
    }

    private void DoBoom(TruckFSM truck)
    {
        //get the material component
        //create a sinus curve of float.
        //change b and g channel of "tint" in material.
        Color truckNewColor = truck.truckMaterial.GetColor("_Color");
        sinX += Time.deltaTime;
        truckNewColor.g = truckNewColor.b = Mathf.Sin(sinX * 6);
        truck.truckMaterial.SetColor("_Color", truckNewColor);
        truck.timeUntilBoom -= Time.deltaTime;
        if(truck.timeUntilBoom <= 0)
        {
            Object.Destroy(truck.gameObject);
        }
    }
}
