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
    /// 아이템 드랍 이후 위 1(Invoke)초 후 콜라이더 활성화 메소드
    /// </summary>
    private void ActiveItemCollider()
    {
        if (itemCollider != null)
        {
            itemCollider.enabled = true;
        }
    }
    /// <summary>
    /// 꽝 아이템이 나올시 0.9(Invoke)초 이후 아이템 삭제
    /// </summary>
    private void DestroyItem()
    {
        Destroy(gameObject);
    }
    /// <summary>
    /// 아이템 픽업 관한 코드 (미작성)
    /// </summary>
    private void ItemPickUp()
    {
        // 해당 아이템 인벤토리로 이동
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 이벤트 Player 태그 충돌 감지
        if (collision.gameObject.tag == "Player")
        {
            ItemPickUp();
        }
    }
}
