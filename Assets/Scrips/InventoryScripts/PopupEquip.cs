using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupEquip : MonoBehaviour
{
    public TMP_Text infoText;
    public Button confirmBtn;

    public void PopupSetting(Items data)
    {
        if(data.isEquiped)
        {
            infoText.text = "장착을 해제하시겠습니까?";
            confirmBtn.onClick.RemoveAllListeners();
            confirmBtn.onClick.AddListener(() => { data.isEquiped = false; });

        }
        else
        {
            infoText.text = "장착 하시겠습니까?";
            confirmBtn.onClick.RemoveAllListeners();
            confirmBtn.onClick.AddListener(() => { data.isEquiped = true; });
        }
    }
}
