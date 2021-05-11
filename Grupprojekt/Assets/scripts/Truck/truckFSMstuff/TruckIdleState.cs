using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckIdleState : INPCState
{
    public INPCState DoState(TruckFSM truck)
    {
        if (truck.truckIsGrounded && truck.isFlipped())
        {
            return truck.truckBoomState;
        }
        if (truck.truckIsGrounded && truck.playerTouchingTruck)
        {
            return truck.truckDriveState;
        }

        return truck.truckIdleState;
    }
    private void DoIdle()
    {
        //do nothing
    }
}
