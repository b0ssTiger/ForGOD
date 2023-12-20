using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Item/ItemData/ItemDefault", order = 0)]
public class ItemSO : ScriptableObject
{
    [Header("ItemData")]
    public string itemName; // 아이템 이름
    

    [Serializable] // 직렬화 (byte)
    public struct STAT
    {
        public string name; // 능력치 이름
        public int value; // 능력치 값
    }

    public List<STAT> stats = new List<STAT>();

    public bool equip; // 이 아이템이 장비면 true ,소모품이면 false
    public bool isEquiped; // 장비라면 장착 일시 true, 장착 안할시 false

    public int maxStack; // 최대 개수
    public int minLevel; // 최소 레벨

    public Sprite icon; // 아이템 이미지
    public Transform prefab; // 드랍 위치

    [TextArea]
    public string itemDescription; // 아이템 설명
}
