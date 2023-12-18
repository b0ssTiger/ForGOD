using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Item/ItemData/ItemDefault", order = 0)]
public class ItemSO : ScriptableObject
{
    [Header("ItemData")]
    public string itemName;
    

    [Serializable] // 직렬화 (byte)
    public struct STAT
    {
        public string name;
        public int value;
        public bool Equip;
    }

    public List<STAT> stats = new List<STAT>();

    public int maxStack; // 최대 개수
    public int minLevel; // 최소 레벨

    public Sprite icon; // 아이템 이미지
    public Transform prefab; // 드랍 위치

    [TextArea]
    public string itemDescription;
}
