using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CloseMonster : MonoBehaviour
{
    public int maxHp;
    private int currentHp;
    public float speed;
    GameObject player;
    private Camera mainCamera;
    public float followDistance;

    void Start()
    {
        mainCamera = Camera.main; // 메인 카메라에 대한 참조를 가져오는 코드
        currentHp = maxHp;
        player = GameObject.Find("Player");
    }
    void Update()
    {
        MonsterMove();       
    }

    public void Move(Transform player)
    {
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        

        if (currentHp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TakeDamage(10);
        }
    }

    void MonsterMove()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
       
        if (distanceToPlayer <= followDistance)
        {
            Move(player.transform);
        }

        Vector3 viewportPos = mainCamera.WorldToViewportPoint(player.transform.position);
       
        if (viewportPos.x > 0.5f)
        {
            
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
           
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }



}
