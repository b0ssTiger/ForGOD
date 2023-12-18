using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Item/ItemData/ItemDefault", order = 0)]
public class ItemSO : ScriptableObject
{
    [Header("ItemData")]
    public string itemName;
    

    [Serializable] // ����ȭ (byte)
    public struct STAT
    {
        public string name;
        public int value;
        public bool Equip;
    }

    public List<STAT> stats = new List<STAT>();

    public int maxStack; // �ִ� ����
    public int minLevel; // �ּ� ����

    public Sprite icon; // ������ �̹���
    public Transform prefab; // ��� ��ġ

    [TextArea]
    public string itemDescription;
}
