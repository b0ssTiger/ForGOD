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
        // 이벤트 Player 태그 충돌 감지
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
    /// Player 태그 오브젝트 충돌감지 이후
    /// ItemDropSO에 ItemDrop메소드 를 통해 해당 위치에 랜덤 아이템 인스턴스 생성
    /// 이후 상자 파괴
    /// </summary>
    public void GetChast()
    {
        itemDropSO.ItemDrop(transform.position);
        Destroy(gameObject);
    }
}
