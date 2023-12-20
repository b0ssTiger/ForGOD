using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeAtk : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayer;
    public UserData userData;
    private CloseMonster enemy1;
    private BossMonster enemy2;

    public float atkRange = 2f; // ���ݹ���

    private void Awake()
    {
        enemy1.GetComponent<CloseMonster>();
        enemy2.GetComponent<BossMonster>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetTrigger("Slash");
            Attack();
        }
    }

    public void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, atkRange, LayerMask.GetMask("Enemy"));

        int MeleeDamage = userData.Player_Stats.atk;

        // �� ���� ���� �������� ����
        foreach (Collider2D enemy in hitEnemies)
        {
            
            enemy1.TakeDamage(MeleeDamage);
            enemy2.TakeDamage(MeleeDamage);

                   
        }
    }
}
