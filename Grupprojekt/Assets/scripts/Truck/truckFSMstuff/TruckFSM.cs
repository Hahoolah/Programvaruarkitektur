using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INPCState
{
    INPCState DoState(TruckFSM truck);
}

public class TruckFSM : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float timeUntilBoom = 5;
    [SerializeField]
    public INPCState currentState;
    [HideInInspector]
    public TruckIdleState truckIdleState = new TruckIdleState();
    public TruckBoomState truckBoomState = new TruckBoomState();
    public TruckDriveState truckDriveState = new TruckDriveState();
    private string currentStateName;

    //former TRUCKFORWARDMOVEMENT
    [HideInInspector]
   public Rigidbody rb;
    [HideInInspector]
    public GameObject frontObject;
    [HideInInspector]
    public Vector3 front;
    LevelLogicManager levelManager;
    
    public float truckSpeed = 3;
    public AudioSource audio1;
    public AudioSource audio2;
    public float playerDistance = 0f;

    // for handling boomState
    public bool truckIsGrounded;
    public int angleToTriggerBoomState;
    public Material truckMaterial;

    //for handling idlestate
    public bool playerTouchingTruck;
    void Start()
    {
        currentState = truckIdleState;

        frontObject = gameObject.transform.Find("front").gameObject; // find the front gameObject.
        rb = GetComponent<Rigidbody>();  //find the rigidbody
        truckMaterial = gameObject.transform.Find("Truck 1 Cargo").GetComponent<Renderer>().material;
        levelManager = GameObject.FindGameObjectWithTag("LevelLogicManager").GetComponent<LevelLogicManager>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentState == truckDriveState)
        {
            Debug.Log(currentState.ToString());
        }
        front = frontObject.transform.position - gameObject.transform.position; //calculate what is forward using the front gameobject.
        front.z = 0;
        front = front.normalized;

        truckIdleState.SetPlayerDistance(playerDistance);
        currentState = currentState.DoState(this);
        currentStateName = currentState.ToString();

    }

    public Vector3 GetDirection()
    {
        return front;
    }

    public float GetSpeed()
    {
        return truckSpeed;
    }

    public void SetPlayerDistance(float aDistance)
    {
        playerDistance = aDistance;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            levelManager.PlayerTruckCollision(this.gameObject);
            playerTouchingTruck = true;
        }
        if(collision.gameObject.CompareTag("Road"))
        {
            truckIsGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerTouchingTruck = false;
            levelManager.PlayerTruckStopCollision();
        }

        if (collision.gameObject.CompareTag("Road"))
        {
            truckIsGrounded = false;
        }
    }

    public void setPitch(float pitch)
    {
        audio1.pitch = pitch;
        audio2.pitch = pitch;
    }

    public bool isFlipped()
    {
        return Vector3.Angle(gameObject.transform.up, Vector3.up) > angleToTriggerBoomState;
    }

    private void OnDestroy()
    {
        //CameraShake camShake = Camera.main.GetComponent<CameraShake>();
        //camShake.StartCoroutine(camShake.Shake(0.5f, 1));
    }
}
