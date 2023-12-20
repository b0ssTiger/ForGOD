using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class UImanager : MonoBehaviour
{
    // �κ��丮�� ������ ��, ������ ���Կ� ������ �������� ������.
    public ItemSlot[] itemslots;

    public void SetInventory()
    {
        int maxItems = DataManager.instance.gameData.myItems.Length;

        // ������ ������ ����.
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
        // ���ο� ������ �����ϰ� �������� �ʱ�ȭ�Ͽ� �߰��մϴ�.
        // ���⼭ ���ο� ������ �����ϴ� �ڵ带 �ۼ��ؾ� �մϴ�.
        // ���� ���, UI�� ���ο� ������ �߰��ϴ� ����� ���� �� �ֽ��ϴ�.
        // ���ο� ������ �߰��ϴ� �ڵ带 �ۼ����ּ���.
        // ����:
        // ItemSlot newSlot = Instantiate(itemSlotPrefab, parentTransform);
        // newSlot.Init(newItem);
    }
}