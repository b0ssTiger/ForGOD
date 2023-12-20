using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class UImanager : MonoBehaviour
{
    // 인벤토리를 열었을 때, 아이템 슬롯에 아이템 정보들이 들어가야함.
    public ItemSlot[] itemslots;

    public void SetInventory()
    {
        int maxItems = DataManager.instance.gameData.myItems.Length;

        // 아이템 정보를 넣음.
        for (int i = 0; i < itemslots.Length; i++)
        {
            if (i < maxItems)
            {
                itemslots[i].Init(DataManager.instance.gameData.myItems[i]);
            }

        }
    }

    private void CreateNewSlotAndInitItem(Item newItem)
    {
        // 새로운 슬롯을 생성하고 아이템을 초기화하여 추가합니다.
        // 여기서 새로운 슬롯을 생성하는 코드를 작성해야 합니다.
        // 예를 들어, UI에 새로운 슬롯을 추가하는 방법이 있을 수 있습니다.
        // 새로운 슬롯을 추가하는 코드를 작성해주세요.
        // 예시:
        // ItemSlot newSlot = Instantiate(itemSlotPrefab, parentTransform);
        // newSlot.Init(newItem);
    }
}