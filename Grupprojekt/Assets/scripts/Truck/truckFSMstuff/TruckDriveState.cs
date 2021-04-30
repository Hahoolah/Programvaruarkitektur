using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckDriveState : INPCState
{

    public INPCState DoState(TruckFSM truck)
    {
        return truck.truckBoomState;
        DoDrive();
        
    }


    private void DoDrive()
    {
        
    }
}
