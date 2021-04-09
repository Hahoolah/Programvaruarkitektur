using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TruckForwardMovement : MonoBehaviour
{
    Rigidbody rb;
    GameObject frontObject;
    Vector3 front;
    [SerializeField]
    private float truckSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        frontObject = gameObject.transform.Find("front").gameObject; // find the front gameObject.
        rb = GetComponent<Rigidbody>();  //find the rigidbody
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        front = frontObject.transform.position - gameObject.transform.position; //calculate what is forward using the front gameobject.
        front = front.normalized;
        rb.MovePosition(transform.position + front * Time.deltaTime * truckSpeed); //move truck using rigidbody.
    }
}
