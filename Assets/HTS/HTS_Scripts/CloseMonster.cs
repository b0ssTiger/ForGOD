using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class CloseMonster : MonoBehaviour
{
    public int maxHp;
    private int currentHp;
    public float speed;
    GameObject player;
    public float followDistance;
    private Slider hpbar;
    public float hpbardistance;
   


    void Start()
    {
               
        currentHp = maxHp; //����ü���� Ǯ�ǿ� ���� �ʱ�ȭ �۾�
        player = GameObject.Find("Player"); // �÷��̾� ��ġ�� �˱� ���ؼ� ���ӿ�����Ʈ �÷��̾ Find��
        hpbar = GetComponentInChildren<Slider>(); //Slider������Ʈ�� value ������ ���� ������
        hpbar.maxValue = maxHp; // �ִ�value�� Ǯ�ǿ� ������ �ʱ�ȭ
        hpbar.value = maxHp; // value�� Ǯ�ǿ� ������ �ʱ�ȭ
    }
    void Update()
    {
        MonsterMove();
        UpdateHpBarPosition();


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
        
    }

    void UpdateHpBarPosition()
    {
        // ������ ���� ��ġ�� �������� ü�¹��� ��ġ�� ����
        Vector3 hpBarPosition = transform.position + new Vector3(0f, hpbardistance, 0f); // ���ϴ� ��ġ�� ����
        hpbar.transform.position = Camera.main.WorldToScreenPoint(hpBarPosition);
    }




}
