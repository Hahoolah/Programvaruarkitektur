using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TruckForwardMovement : MonoBehaviour
{
    Rigidbody rb;
    GameObject frontObject;
    Vector3 front;
    LevelLogicManager levelManager;
    private float acceleration = 1;
    [SerializeField]
    private float truckSpeed = 3;
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
        acceleration += 0.003f;
        front = frontObject.transform.position - gameObject.transform.position; //calculate what is forward using the front gameobject.
        front = front.normalized;
        rb.MovePosition(transform.position + front * Time.deltaTime * truckSpeed * acceleration); //move truck using rigidbody.
    }

    public Vector3 GetDirection()
    {
        return front;
    }

    public float GetSpeed()
    {
        return truckSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
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
}
