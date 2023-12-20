using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    private Rigidbody2D rb;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, LayerMask.GetMask("Ground"));

        // มกวม
        if (Input.GetKeyDown(KeyCode.C) && isGrounded)
        {
            DoJump();
        }
        if (!isGrounded)
        {
            
            rb.velocity += Vector2.down * Physics2D.gravity.y * Time.deltaTime;
        }

    }
    public void DoJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
