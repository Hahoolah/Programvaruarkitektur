using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Apple;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    private float jumpForce = 7;
    public float dashCooldown = 0.2f;
    private float dashTempCD;
    private bool isDashing = false;
    public float moveSpeed = 7;
    public int extraJumps;
    private int extraJumpsTemp;
    public float dashBoost;
    private AudioSource audioSource;
    [SerializeField]
    public GameObject levelLogicManager;
    public Transform handPos;
    public GameObject effect;
    void Start()
    {
        extraJumpsTemp = extraJumps;
        dashTempCD = dashCooldown;
        rb = GetComponent<Rigidbody>();
        levelLogicManager = GameObject.FindGameObjectWithTag("LevelLogicManager");
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float y = Input.GetAxis("Vertical") * moveSpeed;
        dashCooldown -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.y);
            extraJumps--;
        }

        if (IsGrounded())
        {
            extraJumps = extraJumpsTemp;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (!audioSource.isPlaying && IsGrounded())
            {
                audioSource.Play();
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldown <= 0.0f)
        {
            dashCooldown = dashTempCD;
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
        if(this.GetComponent<PlayerResource>().UseFlash(3f))
        {
            Vector3 dashDirection = transform.forward;
            rb.AddForce(dashDirection * dashBoost, ForceMode.Impulse);
            isDashing = false;
            Instantiate(effect, handPos);
        }
       
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Road"))
        {
            levelLogicManager.GetComponent<LevelLogicManager>().GameOver();
        }
    }

}