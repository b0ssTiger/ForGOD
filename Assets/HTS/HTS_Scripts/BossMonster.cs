using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;
using static UnityEditor.Progress;

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
    [SerializeField] private GameObject prefab;



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
            float rnd = Random.Range(0,9);
            if (rnd >= 0)
            {
                ItemChaetDrop(transform.position);
            }
            Die();
        }
    }
    public void ItemChaetDrop(Vector3 pos)
    {
        if (prefab == null)
        {
            return;
        }
        Instantiate(prefab, pos, Quaternion.identity);
    }
    public void Die()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isKnockbackInProgress)
        {            

            Vector3 knockbackDirection = (transform.position - collision.transform.position).normalized;

            // �˹� ���� ����
            GetComponent<Rigidbody2D>().AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);

            Invoke("ResetKnockback", 1f);

            // �˹� ���� �� �÷��� ����
            isKnockbackInProgress = true;
        }
    }

    private void ResetKnockback()
    {
        // �˹� ���� �ʱ�ȭ
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        // �˹� ���� �� �÷��� �ʱ�ȭ
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
        // ������ ���� ��ġ�� �������� ü�¹��� ��ġ�� ����
        Vector3 hpBarPosition = transform.position + new Vector3(0f, hpbardistance, 0f); // ���ϴ� ��ġ�� ����
        hpbar.transform.position = Camera.main.WorldToScreenPoint(hpBarPosition);
    }



}
