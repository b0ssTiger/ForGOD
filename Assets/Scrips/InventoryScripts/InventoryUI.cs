//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class InventoryUI : MonoBehaviour
//{
//    [Header("Options")]
//    [Range(0, 10)]
//    [SerializeField] private int _horizontalSlotCount = 8;  // ���� ���� ����
//    [Range(0, 10)]
//    [SerializeField] private int _verticalSlotCount = 8;      // ���� ���� ����
//    [SerializeField] private float _slotMargin = 8f;          // �� ������ �����¿� ����
//    [SerializeField] private float _contentAreaPadding = 20f; // �κ��丮 ������ ���� ����
//    [Range(32, 64)]
//    [SerializeField] private float _slotSize = 64f;      // �� ������ ũ��

//    [Header("Connected Objects")]
//    [SerializeField] private RectTransform _contentAreaRT; // ���Ե��� ��ġ�� ����
//    [SerializeField] private GameObject _slotUiPrefab;     // ������ ���� ������
//    [SerializeField] private List<ItemSlotUI> _slotUIList;

//    /// <summary> ������ ������ŭ ���� ���� ���� ���Ե� ���� ���� </summary>
//    private void InitSlots()
//    {
//        // ���� ������ ����
//        _slotUiPrefab.TryGetComponent(out RectTransform slotRect);
//        slotRect.sizeDelta = new Vector2(_slotSize, _slotSize);

//        _slotUiPrefab.TryGetComponent(out ItemSlotUI itemSlot);
//        if (itemSlot == null)
//            _slotUiPrefab.AddComponent<ItemSlotUI>();

//        _slotUiPrefab.SetActive(false);

//        // --
//        Vector2 beginPos = new Vector2(_contentAreaPadding, -_contentAreaPadding);
//        Vector2 curPos = beginPos;

//        _slotUIList = new List<ItemSlotUI>(_verticalSlotCount * _horizontalSlotCount);

//        // ���Ե� ���� ����
//        for (int j = 0; j < _verticalSlotCount; j++)
//        {
//            for (int i = 0; i < _horizontalSlotCount; i++)
//            {
//                int slotIndex = (_horizontalSlotCount * j) + i;

//                var slotRT = CloneSlot();
//                slotRT.pivot = new Vector2(0f, 1f); // Left Top
//                slotRT.anchoredPosition = curPos;
//                slotRT.gameObject.SetActive(true);
//                slotRT.gameObject.name = $"Item Slot [{slotIndex}]";

//                var slotUI = slotRT.GetComponent<ItemSlotUI>();
//                var slotUI = slotRT.GetComponent<ItemSlotUI>();
//                slotUI.SetSlotIndex(slotIndex);
//                _slotUIList.Add(slotUI);

//                // Next X
//                curPos.x += (_slotMargin + _slotSize);
//            }

//            // Next Line
//            curPos.x = beginPos.x;
//            curPos.y -= (_slotMargin + _slotSize);
//        }

//        // ���� ������ - �������� �ƴ� ��� �ı�
//        if (_slotUiPrefab.scene.rootCount != 0)
//            Destroy(_slotUiPrefab);

//        // -- Local Method --
//        RectTransform CloneSlot()
//        {
//            GameObject slotGo = Instantiate(_slotUiPrefab);
//            RectTransform rt = slotGo.GetComponent<RectTransform>();
//            rt.SetParent(_contentAreaRT);

//            return rt;
//        }
//    }
//}
