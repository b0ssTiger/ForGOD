using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    // �κ��丮�� ������ ��, ������ ���Կ� ������ �������� ������.
    public ItemSlot[] itemslots;
                       
    public void SetInventory()
    {

        //������ ������ ����.
        for (int i = 0; i < DataManager.instance.gameData.myItems.Length; i++)
        {
            itemslots[i].Init(DataManager.instance.gameData.myItems[i]);

            //���� ���� myItems�� ���� ���.
            //���1 ���� �ִ���� ������.
            //���2 ���Ժ��� ���� �������� �������� ������ �� �����Ѵ�.

        }
    }
}