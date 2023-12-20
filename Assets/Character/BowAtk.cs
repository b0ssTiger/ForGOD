using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowAtk : MonoBehaviour
{
    public Animator animator;
    public GameObject projectilePrefab;  // �߻��� ����ü ������
    public Transform shootingPoint;      // ����ü �߻� ����
    public float projectileSpeed = 10f;  // ����ü �ӵ�
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
        // �÷��̾ �ٶ󺸴� ������ ��������
        Vector3 shootingDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;

        // ����ü ����
        GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, Quaternion.identity);

        // ����ü�� �ӵ� ����
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(shootingDirection.x, shootingDirection.y) * projectileSpeed;

        // ����ü ���� ����
        float angle = Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg;
        projectile.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
