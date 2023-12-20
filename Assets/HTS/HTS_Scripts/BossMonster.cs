using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossMonster : MonoBehaviour
{
    public int maxHp;
    private int currentHp;
    public float speed;
    GameObject player;
    public float followDistance;
    private Slider hpbar;
    public float hpbardistance;
    public float knockbackForce = 1f;
    private bool isKnockbackInProgress = false;




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
        if (collision.gameObject.tag == "Player" && !isKnockbackInProgress)
        {
            TakeDamage(10);

            Vector3 knockbackDirection = (transform.position - collision.transform.position).normalized;

            // 넉백 힘을 가함
            GetComponent<Rigidbody2D>().AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);

            Invoke("ResetKnockback", 1f);

            // 넉백 진행 중 플래그 설정
            isKnockbackInProgress = true;
        }
    }

    private void ResetKnockback()
    {
        // 넉백 힘을 초기화
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        // 넉백 진행 중 플래그 초기화
        isKnockbackInProgress = false;
    }

    void MonsterMove()
    {
        Vector2 distanceToPlayer = player.transform.position - transform.position;

        if (distanceToPlayer.magnitude <= followDistance)
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
