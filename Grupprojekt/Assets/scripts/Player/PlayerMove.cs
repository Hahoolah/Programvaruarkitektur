using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Apple;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    private float jumpForce = 7;
    private float dashCooldown = 0.2f;
    private bool isDashing = false;
    public float moveSpeed = 7;
    public float dashBoost;
    private AudioSource audioSource;
    [SerializeField]
    public GameObject levelLogicManager;

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
        dashCooldown -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (!audioSource.isPlaying && IsGrounded())
            {
                audioSource.Play();
            }
        }
        if(Input.GetKeyDown(KeyCode.LeftShift) && dashCooldown <= 0.0f)
        {
            dashCooldown = 0.2f;
            isDashing = true;
        }

        Vector3 movePos = transform.right * x + transform.forward * y;
        Vector3 newMovePos = new Vector3(movePos.x, rb.velocity.y, movePos.z);

        rb.velocity = newMovePos;

    }

    void FixedUpdate()
    {
        if (isDashing)
            Dashing();
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, 1);
    }

    private void Dashing()
    {
        Vector3 dashDirection = transform.forward;
        rb.AddForce(dashDirection * dashBoost, ForceMode.Impulse);
        isDashing = false;
    }

    public void LockToTruck(Vector3 aDirection, float aSpeed)
    {
        float x = aDirection.x * aSpeed;
        float y = aDirection.y * aSpeed;

        Vector3 deltaPos = rb.velocity;
        deltaPos.x += x;
        deltaPos.y += y;

        rb.position += deltaPos * Time.deltaTime;
        Debug.Log("fml");

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Road"))
        {
            levelLogicManager.GetComponent<LevelLogicManager>().GameOver();
        }
    }

}
