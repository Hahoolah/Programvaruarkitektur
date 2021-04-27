using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TruckForwardMovement : MonoBehaviour
{
    Rigidbody rb;
    GameObject frontObject;
    Vector3 front;
    LevelLogicManager levelManager;
    bool grounded = false;
    [SerializeField]
    private float truckSpeed = 3;
    public AudioSource audio1;
    public AudioSource audio2;
  
    // Start is called before the first frame update
    void Start()
    {
        frontObject = gameObject.transform.Find("front").gameObject; // find the front gameObject.
        rb = GetComponent<Rigidbody>();  //find the rigidbody
        levelManager = GameObject.FindGameObjectWithTag("LevelLogicManager").GetComponent<LevelLogicManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        front = frontObject.transform.position - gameObject.transform.position; //calculate what is forward using the front gameobject.
        front = front.normalized;      
        rb.MovePosition(transform.position + front * truckSpeed * Time.deltaTime); //move truck using rigidbody.
       
    }

    public Vector3 GetDirection()
    {
        return front;
    }

    public float GetSpeed()
    {
        return truckSpeed;
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, 3);
    }
   
        
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Road"))
        {
            grounded = true;                        
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            levelManager.PlayerTruckCollision(this.gameObject);
        }

    }



    private void OnCollisionExit(Collision collision)
    {  
        
        if (collision.gameObject.CompareTag("Player"))
        {
            levelManager.PlayerTruckStopCollision();
        }
    }

    public void setPitch(float pitch)
    {
        audio1.pitch = pitch;
        audio2.pitch = pitch;
    }
}
