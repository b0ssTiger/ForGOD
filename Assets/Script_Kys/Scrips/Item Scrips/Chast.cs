using UnityEngine;

public class Chast : MonoBehaviour
{
    public ItemDropSO itemDropSO;
    private BoxCollider2D Collider;

    private void Awake()
    {
        Collider = GetComponent<BoxCollider2D>();
        Invoke("ActiveItemCollider", 1f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �̺�Ʈ Player �±� �浹 ����
        if (collision.gameObject.tag == "Player")
        {
            GetChast();
        }
    }
    private void ActiveItemCollider()
    {
        if (Collider != null)
        {
            Collider.enabled = true;
        }
    }
    /// <summary>
    /// Player �±� ������Ʈ �浹���� ����
    /// ItemDropSO�� ItemDrop�޼ҵ� �� ���� �ش� ��ġ�� ���� ������ �ν��Ͻ� ����
    /// ���� ���� �ı�
    /// </summary>
    public void GetChast()
    {
        itemDropSO.ItemDrop(transform.position);
        Destroy(gameObject);
    }
}
