using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [HideInInspector] public ItemSO inputData;
   
    public PopupEquip popupEquip;
    public Image itemImage;
    public GameObject EquipMark;

    public void Init(ItemSO data)
    {
        inputData = data;
        itemImage.sprite = data.icon;
        itemImage.enabled = true;

        ChangeEquip();


    }

    public void ChangeEquip()
    {
        if (inputData.isEquiped)
        {
            EquipMark.SetActive(true);
        }
        else
        {
            EquipMark.SetActive(false);
        } 
    }

    public void Popup()
    {
        if(inputData != null)
            popupEquip.PopupSetting(this);


    }


}
