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
    public float knockbackForce = 2f;


    void Start()
    {
        
        mainCamera = Camera.main; // 메인 카메라에 대한 참조를 가져오는 코드
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
            //넉백 쓰는거 잘 모르겠음 넉백방향 구하는것까지 알겠음
            Vector3 knockbackDirection = (transform.position - collision.transform.position).normalized;
            // 넉백을 적용하기 전에 현재 힘 초기화, 넉백 방향에 힘을 가함 라는데 흠...
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            GetComponent<Rigidbody2D>().AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
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

    void UpdateHpBarPosition()
    {
        // 몬스터의 현재 위치를 기준으로 체력바의 위치를 조절
        Vector3 hpBarPosition = transform.position + new Vector3(0f, hpbardistance, 0f); // 원하는 위치로 조절
        hpbar.transform.position = Camera.main.WorldToScreenPoint(hpBarPosition);
    }



}
