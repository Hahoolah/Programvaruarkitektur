using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLogicManager : MonoBehaviour
{
    public GameObject[] myTruckArray;
    GameObject myCollidingTruck;
    public GameObject myPlayer;

    // Start is called before the first frame update
    void Start()
    {
        myTruckArray = GameObject.FindGameObjectsWithTag("Truck");
        myPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (myCollidingTruck != null)
        {
            myPlayer.GetComponent<PlayerMove>().LockToTruck(myCollidingTruck.GetComponent<TruckForwardMovement>().GetDirection(), myCollidingTruck.GetComponent<TruckForwardMovement>().GetSpeed());
        }
       
    }

    public void PlayerTruckCollision(GameObject aCollidingTruck)
    {
        myCollidingTruck = aCollidingTruck;
    }

    public void PlayerTruckStopCollision()
    {
        myCollidingTruck = null;
    }
}
