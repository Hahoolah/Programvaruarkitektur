using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckBoomState : INPCState
{
    public INPCState DoState(TruckFSM truck)
    {
        return truck.truckBoomState; 
    }

    private void DoBoom()
    {

    }
}
