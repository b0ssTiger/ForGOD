using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class meleeAtk : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayer;
    DataManager _Player;

    public float atkRange = 0.5f; // 공격범위

    void Start()
    {
        _Player = DataManager.instance;
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

        int MeleeDamage = _Player.play_data.atk;

        
        foreach (Collider2D enemy in hitEnemies)
        {
            BossMonster bossMonster = enemy.GetComponent<BossMonster>();
            CloseMonster closeMonster = enemy.GetComponent<CloseMonster>();

           
            if (bossMonster != null)
            {
                bossMonster.TakeDamage(MeleeDamage);
            }
            else if (closeMonster != null)
            {
                closeMonster.TakeDamage(MeleeDamage);
            }
        }
    }
}
