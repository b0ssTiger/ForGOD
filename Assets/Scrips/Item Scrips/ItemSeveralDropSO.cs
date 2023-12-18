using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSeveralDrop", menuName = "Item/ItemData/ItemSeveralDrop", order = 2)]
public class ItemSeveralDropSO : ScriptableObject
{
    [Serializable]
    public class Items
    {
        public ItemSO item;
        public int weight;
    }

    public List<Items> items = new List<Items>();
    
    protected ItemSO PickItem()
    {
        int sum = 0;
        foreach (var item in items)
        {
            sum += item.weight;
        }

        float rnd = UnityEngine.Random.Range(0, sum); // 아이템 확률
        int rnd1 = UnityEngine.Random.Range(0, 5); // 아이템 나오는 개수
        int rnd1Count = 0;
        List<ItemSO> list = new List<ItemSO>();
        while (rnd1 != 0)
        {
            for (int i = 0; i < items.Count; i++)
            {
                var item = items[i];
                if (item.weight > rnd)
                {
                    list[rnd1Count] = items[i].item;
                    rnd1Count++;
                }
                else
                {
                    rnd -= item.weight;
                }
            }
            rnd1--;
        }
        if (list[rnd1Count] == null)
        {
            return null;
        }
        return list[rnd1Count];
    }

    public void ItemDrop(Vector3 pos)
    {
        var item = PickItem();
        if (item == null)
        {
            return;
        }
        Instantiate(item.prefab, pos, Quaternion.identity);
    }
}
