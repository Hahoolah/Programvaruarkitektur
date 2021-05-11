using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckIdleState : INPCState
{
    float playerDistance = float.MaxValue;
    float driveStateActivationDistance = 100f;

    public INPCState DoState(TruckFSM truck)
    {
        if (truck.truckIsGrounded && truck.isFlipped())
        {
            return truck.truckBoomState;
        }
        if (truck.truckIsGrounded && playerDistance <= driveStateActivationDistance)
        {
            return truck.truckDriveState;
        }

        return truck.truckIdleState;
    }

    public void SetPlayerDistance(float aPlayerDistance)
    {
        playerDistance = aPlayerDistance;
    }

    private void DoIdle()
    {
        //do nothing
    }
}
