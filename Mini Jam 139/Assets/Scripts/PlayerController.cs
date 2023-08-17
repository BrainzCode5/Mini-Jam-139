using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    public float jumpForce;
    public int startExtraJumps;
    public LayerMask whatIsGround;
    public Transform groundCheck;

    public KeyCode jumpKey;

    private Rigidbody2D rb;
    private float movement;
    private int extraJumps;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        extraJumps = startExtraJumps;
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        movement = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movement, 0f, 0f) * speed * Time.deltaTime;

        //Jumping
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.5f, whatIsGround); //Checking If Player Is Grounded

        if (Input.GetKeyDown(jumpKey) && extraJumps >= 1)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        if (isGrounded == true)
        {
            extraJumps = startExtraJumps;
        }
    }
}
