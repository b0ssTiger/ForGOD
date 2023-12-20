using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    // 인벤토리를 열었을 때, 아이템 슬롯에 아이템 정보들이 들어가야함.
    public ItemSlot[] itemslots;
                       
    public void SetInventory()
    {

        //아이템 정보를 넣음.
        for (int i = 0; i < DataManager.instance.gameData.myItems.Length; i++)
        {
            itemslots[i].Init(DataManager.instance.gameData.myItems[i]);

            //슬롯 보다 myItems가 많을 경우.
            //방법1 보유 최대수를 한정함.
            //방법2 슬롯보다 보유 아이템이 많아지면 슬롯을 더 생성한다.

        }
    }
}