using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;

public class Chast : MonoBehaviour
{
    public ItemDropSO itemDropSO;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetChast();
        }
    }
    public void GetChast()
    {
        itemDropSO.ItemDrop(transform.position);
        Destroy(gameObject);
    }
}
