using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public Transform ItenPoint;
    public Transform groundCheck;
    public GameObject ItemPrefab;
    public GameObject BowPrefab;
    public LayerMask groundLayer;
    private Rigidbody2D rb;
    public Animator animator;

    public float Curhp;
    public float moveSpeed = 1f;
    public float jumpForce = 10f;
    public float groundCheckRadius = 0.2f;

    public bool isGrounded;

    [SerializeField]
    private Transform shotPointTransform = null;
   


    void Start()
    {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
              
        if (x != 0 || y != 0)
        {
            animator.SetFloat("x", x);
            animator.SetFloat("y", y);
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }

        Vector2 moveDirection = new Vector2(x, y);
        moveDirection.Normalize();

        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        if (Input.GetKeyDown(KeyCode.C) && isGrounded)
        {
            Jump();
        }
        
        StartCoroutine(Action());
        StartCoroutine(Shot());
    }

    void FixedUpdate()
    {
        // 땅에 닿았는지 검사
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // 자동으로 내려오기
        if (!isGrounded)
        {
            // 여기에서는 간단하게 중력을 적용하여 자연스러운 떨어짐 효과를 구현합니다.
            rb.velocity += Vector2.down * Physics2D.gravity.y * Time.fixedDeltaTime;
        }
    }
    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
    IEnumerator Action()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetTrigger("Slash");
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            animator.SetTrigger("Item");
            Instantiate(ItemPrefab, ItenPoint.position, transform.rotation);
        }
                              
        if (Input.GetKeyDown(KeyCode.N))
        {
            animator.SetTrigger("Damage");
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            animator.SetTrigger("Dead");
            this.transform.position = new Vector2(0f, -0.12f);
            for (var i = 0; i < 64; i++)
            {
                yield return null;
            }
            this.transform.position = Vector2.zero;
        }
    }
    IEnumerator Shot()
    {
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetTrigger("Bow");
            for (var i = 0; i < 40; i++)
            {
                yield return null;
            }
            Instantiate(BowPrefab, Vector2.zero, Quaternion.identity, shotPointTransform);
        }  
       
    }
}




