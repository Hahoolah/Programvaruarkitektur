using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLogicManager : MonoBehaviour
{
    public List<GameObject> myTruckList;
    GameObject myCollidingTruck;
    public GameObject myPlayer;
    private AudioSource audio;
    [SerializeField]
    public AudioClip deathSound;

    // Start is called before the first frame update
    void Start()
    {
        myPlayer = GameObject.FindGameObjectWithTag("Player");
        audio = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myCollidingTruck != null)
        {
            myPlayer.GetComponent<PlayerMove>().LockToTruck(myCollidingTruck.GetComponent<TruckFSM>().GetDirection(), myCollidingTruck.GetComponent<TruckFSM>().GetSpeed());
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


    public void GameOver()
    {
        audio.clip = deathSound;
        audio.Play();
        SceneManager.LoadScene("EndMenu");
    }

    public void Finish(string map)
    {
        SceneManager.LoadScene(map);
    }

    public void AddTruckToList(GameObject truck)
    {
        myTruckList.Add(truck);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void DeleteTruckFromList(GameObject truck)
    {
        myTruckList.Remove(truck);
    }

    public List<GameObject> GetTruckList()
    {
        return myTruckList;
    }
}
