using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    public List<GameObject> myTruckList;
    AudioSource audio;
    [SerializeField]
    public Camera camera;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        myTruckList = gameObject.GetComponent<LevelLogicManager>().GetTruckList();
        audio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.E))
        {
            SlowMotion();
        }
       else
        {
            ResetSlowMotion();
        }
       
    }

    private void SlowMotion()
    {
        Time.timeScale = 0.4f;
        audio.pitch = 0.4f;
        camera.fieldOfView = 90;

        foreach (var truck in myTruckList)
        {
            if (truck != null)
            {
                truck.GetComponent<TruckFSM>().setPitch(0.4f);
            }
           
        }

        player.GetComponent<AudioSource>().pitch = 0.4f;
    }

    private void ResetSlowMotion()
    {
        Time.timeScale = 1;
        audio.pitch = 1;
        camera.fieldOfView = 80;

        foreach (var truck in myTruckList)
        {
            if (truck != null)
            {
                truck.GetComponent<TruckFSM>().setPitch(1f);
            }
            
        }

        player.GetComponent<AudioSource>().pitch = 1;
      
    }
}
