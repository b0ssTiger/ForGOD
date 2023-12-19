using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CloseMonster : MonoBehaviour
{
    public int maxHp;
    private int currentHp;
    public float speed;
    GameObject player;
    private Camera mainCamera;
    public float followDistance;
    private Slider hpbar;
    public float hpbardistance;


    void Start()
    {
        
        mainCamera = Camera.main; // ���� ī�޶� ���� ������ �������� �ڵ�
        currentHp = maxHp;
        player = GameObject.Find("Player");
        hpbar = GetComponentInChildren<Slider>();
        hpbar.maxValue = maxHp;
        hpbar.value = maxHp;
    }
    void Update()
    {
        MonsterMove();
        UpdateHealthBarPosition();


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
        hpbar.value = currentHp;


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

    void UpdateHealthBarPosition()
    {
        // ������ ���� ��ġ�� �������� ü�¹��� ��ġ�� ����
        Vector3 healthBarPosition = transform.position + new Vector3(0f, hpbardistance, 0f); // ���ϴ� ��ġ�� ����
        hpbar.transform.position = Camera.main.WorldToScreenPoint(healthBarPosition);
    }



}
