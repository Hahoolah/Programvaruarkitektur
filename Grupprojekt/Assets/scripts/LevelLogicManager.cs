using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLogicManager : MonoBehaviour
{
    public GameObject[] myTruckArray;
    GameObject myCollidingTruck;
    public GameObject myPlayer;
    private AudioSource audio;
    [SerializeField]
    public AudioClip deathSound;

    // Start is called before the first frame update
    void Start()
    {
        myTruckArray = GameObject.FindGameObjectsWithTag("Truck");
        myPlayer = GameObject.FindGameObjectWithTag("Player");
        audio = this.GetComponent<AudioSource>();
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
        myCollidingTruck.GetComponent<TruckRemoval>().SetDestroyTruck(true);
    }

    public void PlayerTruckStopCollision()
    {
        myCollidingTruck = null;
    }


    public void GameOver()
    {
        audio.clip = deathSound;
        audio.Play();
        // TODO: END GAME SCREEN
    }
}
