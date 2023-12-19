using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField] private ItemSO itemSO;
    private BoxCollider2D itemCollider;
    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        itemCollider = GetComponent<BoxCollider2D>();

        if ( sprite != null )
        {
            sprite.sprite = itemSO.icon;
            Invoke("ActiveItemCollider", 1f);
        }
        if (itemSO.itemName == "FailedItem")
        {
            Invoke("DestroyItem", 0.9f);
        }
    }

    /// <summary>
    /// ������ ��� ���� �� 1(Invoke)�� �� �ݶ��̴� Ȱ��ȭ �޼ҵ�
    /// </summary>
    private void ActiveItemCollider()
    {
        if (itemCollider != null)
        {
            itemCollider.enabled = true;
        }
    }
    /// <summary>
    /// �� �������� ���ý� 0.9(Invoke)�� ���� ������ ����
    /// </summary>
    private void DestroyItem()
    {
        Destroy(gameObject);
    }
    /// <summary>
    /// ������ �Ⱦ� ���� �ڵ� (���ۼ�)
    /// </summary>
    private void ItemPickUp()
    {
        // �ش� ������ �κ��丮�� �̵�
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �̺�Ʈ Player �±� �浹 ����
        if (collision.gameObject.tag == "Player")
        {
            ItemPickUp();
        }
    }
}
