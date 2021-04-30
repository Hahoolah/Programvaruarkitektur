using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckIdleState : INPCState
{
    public INPCState DoState(TruckFSM truck)
    {
        return truck.truckIdleState;
    }
    private void DoIdle()
    {

    }
}
