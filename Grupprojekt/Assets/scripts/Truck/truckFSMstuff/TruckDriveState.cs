using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckDriveState : TruckFSM
{

    public INPCState DoState(TruckFSM truck)
    {
        DoDrive();
    }


    private void DoDrive()
    {
        
    }
}
