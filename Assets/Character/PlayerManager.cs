using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public Transform ItenPoint;
    public Transform ShotPoint;
    public GameObject ItemPrefab;
    public GameObject BowPrefab;

    public float Curhp;

    Rigidbody2D rb;
    Animator animator;
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
        float y = (x == 0) ? Input.GetAxisRaw("Vertical") : 0.0f;
        

        
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

        Vector3 moveDirection = new Vector3(x, y, 0f).normalized;

        // 이동 벡터가 0이 아닐 때만 이동 처리
        if (moveDirection.magnitude >= 0.1f)
        {
            // 플레이어 이동
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }

        StartCoroutine(Action());
        StartCoroutine(Shot());
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




