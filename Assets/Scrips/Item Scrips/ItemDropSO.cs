using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDrop", menuName = "Item/ItemData/ItemDrop", order = 1)]
public class ItemDropSO : ScriptableObject
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

        float rnd = UnityEngine.Random.Range(0, sum); // æ∆¿Ã≈€ »Æ∑¸
        for (int i = 0; i < items.Count; i++)
        {
            var item = items[i];
            if (item.weight > rnd)
            {
                return items[i].item;
            }
            else
            {
                rnd -= item.weight;
            }
        }
        return null;
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
