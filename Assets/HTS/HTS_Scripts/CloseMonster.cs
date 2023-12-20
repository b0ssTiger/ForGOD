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
               
        currentHp = maxHp; //현재체력을 풀피와 같게 초기화 작업
        player = GameObject.Find("Player"); // 플레이어 위치를 알기 위해서 게임오브젝트 플레이어를 Find함
        hpbar = GetComponentInChildren<Slider>(); //Slider컴포넌트를 value 지정을 위해 가져옴
        hpbar.maxValue = maxHp; // 최대value가 풀피와 같도록 초기화
        hpbar.value = maxHp; // value를 풀피와 같도록 초기화
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
        // 몬스터의 현재 위치를 기준으로 체력바의 위치를 조절
        Vector3 hpBarPosition = transform.position + new Vector3(0f, hpbardistance, 0f); // 원하는 위치로 조절
        hpbar.transform.position = Camera.main.WorldToScreenPoint(hpBarPosition);
    }




}
