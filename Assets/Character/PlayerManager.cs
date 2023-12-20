using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public Transform ItenPoint;
    public GameObject ItemPrefab;
    public GameObject BowPrefab;
    private Rigidbody2D rb;
    public Animator animator;

    public float Curhp;
    public float moveSpeed = 1f;


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
        
        
    }
   
    
   
}




