using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowAtk : MonoBehaviour
{
    public Animator animator;
    public GameObject projectilePrefab;  // 발사할 투사체 프리팹
    public Transform shootingPoint;      // 투사체 발사 지점
    public float projectileSpeed = 10f;  // 투사체 속도
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetTrigger("Bow");
            ShootProjectile();
        }
    }
    void ShootProjectile()
    {
        // 플레이어가 바라보는 방향을 가져오기
        Vector3 shootingDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;

        // 투사체 생성
        GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, Quaternion.identity);

        // 투사체에 속도 적용
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(shootingDirection.x, shootingDirection.y) * projectileSpeed;

        // 투사체 방향 설정
        float angle = Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg;
        projectile.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
