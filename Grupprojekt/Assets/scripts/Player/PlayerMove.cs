 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    private float jumpForce = 4;
    bool grounded = true;
    public float moveSpeed = 6;
    private AudioSource audioSource;
    private bool onTruck = false;
 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float y = Input.GetAxis("Vertical") * moveSpeed;

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.y);
            grounded = false;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
       
            Vector3 movePos = transform.right * x + transform.forward * y;
            Vector3 newMovePos = new Vector3(movePos.x, rb.velocity.y, movePos.z);

            rb.velocity = newMovePos;
        
    }

    public void LockToTruck(Vector3 aDirection, float aSpeed)
    {
        float x = aDirection.x * aSpeed;
        float y = aDirection.y * aSpeed;

        Vector3 deltaPos = rb.velocity;
        deltaPos.x += x;
        deltaPos.y += y;

        rb.position += deltaPos * Time.deltaTime;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        grounded = true;
    }
}
