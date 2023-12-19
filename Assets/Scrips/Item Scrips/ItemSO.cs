using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Item/ItemData/ItemDefault", order = 0)]
public class ItemSO : ScriptableObject
{
    [Header("ItemData")]
    public string itemName; // ������ �̸�
    

    [Serializable] // ����ȭ (byte)
    public struct STAT
    {
        public string name; // �ɷ�ġ �̸�
        public int value; // �ɷ�ġ ��
    }

    public List<STAT> stats = new List<STAT>();

    public bool Equip; // ���� ���� ����
    public int maxStack; // �ִ� ����
    public int minLevel; // �ּ� ����

    public Sprite icon; // ������ �̹���
    public Transform prefab; // ��� ��ġ

    [TextArea]
    public string itemDescription; // ������ ����
}
