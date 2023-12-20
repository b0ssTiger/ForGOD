using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeAtk : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayer;
    public UserStat userData;

    public float atkRange = 0.5f; // 공격범위

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

        int MeleeDamage = userData.atk;

        // 각 적에 대해 데미지를 입힘
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<CloseMonster>().TakeDamage(MeleeDamage);
        }
    }
}
