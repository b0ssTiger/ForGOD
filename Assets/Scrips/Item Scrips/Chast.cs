using UnityEngine;

public class Chast : MonoBehaviour
{
    public ItemDropSO itemDropSO;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �̺�Ʈ Player �±� �浹 ����
        if (collision.gameObject.tag == "Player")
        {
            GetChast();
        }
    }
    /// <summary>
    /// Player �±� ������Ʈ �浹���� ����
    /// ItemDropSO�� ItemDrop�޼ҵ� �� ���� �ش� ��ġ�� ���� ������ �ν��Ͻ� ����
    /// </summary>
    public void GetChast()
    {
        itemDropSO.ItemDrop(transform.position);
        Destroy(gameObject);
    }
}
