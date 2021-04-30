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
    private INPCState currentState;
    [HideInInspector]
    public TruckIdleState truckIdleState = new TruckIdleState();
    public TruckBoomState truckBoomState = new TruckBoomState();
    public TruckDriveState truckDriveState = new TruckDriveState();
    private string currentStateName;
    void Start()
    {
        currentState = truckDriveState;

    }

    // Update is called once per frame
    void Update()
    {
        currentState = currentState.DoState(this);
        currentStateName = currentState.ToString();
        //timeUntilBoom -= Time.deltaTime;
        //if (timeUntilBoom <= 0)
        //{

        //    Destroy(gameObject);
        //}


    }

    private void OnDestroy()
    {
        CameraShake camShake = Camera.main.GetComponent<CameraShake>();
        camShake.StartCoroutine(camShake.Shake(0.5f, 1));
    }
}
