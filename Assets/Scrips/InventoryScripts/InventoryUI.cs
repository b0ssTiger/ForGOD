//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class InventoryUI : MonoBehaviour
//{
//    [Header("Options")]
//    [Range(0, 10)]
//    [SerializeField] private int _horizontalSlotCount = 8;  // 슬롯 가로 개수
//    [Range(0, 10)]
//    [SerializeField] private int _verticalSlotCount = 8;      // 슬롯 세로 개수
//    [SerializeField] private float _slotMargin = 8f;          // 한 슬롯의 상하좌우 여백
//    [SerializeField] private float _contentAreaPadding = 20f; // 인벤토리 영역의 내부 여백
//    [Range(32, 64)]
//    [SerializeField] private float _slotSize = 64f;      // 각 슬롯의 크기

//    [Header("Connected Objects")]
//    [SerializeField] private RectTransform _contentAreaRT; // 슬롯들이 위치할 영역
//    [SerializeField] private GameObject _slotUiPrefab;     // 슬롯의 원본 프리팹
//    [SerializeField] private List<ItemSlotUI> _slotUIList;

//    /// <summary> 지정된 개수만큼 슬롯 영역 내에 슬롯들 동적 생성 </summary>
//    private void InitSlots()
//    {
//        // 슬롯 프리팹 설정
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

//        // 슬롯들 동적 생성
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

//        // 슬롯 프리팹 - 프리팹이 아닌 경우 파괴
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
