using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckDriveState : INPCState
{

    public INPCState DoState(TruckFSM truck)
    {
        
        DoDrive(truck.frontObject, truck.gameObject, truck.rb, truck.truckSpeed, truck.front);
        if (truck.truckIsGrounded && truck.isFlipped())
        {
            return truck.truckBoomState;
        }
        return truck.truckDriveState;
    }

    private void DoDrive(GameObject frontObject, GameObject truck, Rigidbody rb, float truckSpeed, Vector3 front)
    {
        front = frontObject.transform.position - truck.transform.position; //calculate what is forward using the front gameobject.
        front = front.normalized;
        rb.MovePosition(truck.transform.position + front * truckSpeed * Time.deltaTime); //move truck using rigidbody.
    }   
}
