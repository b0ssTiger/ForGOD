using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;



public class SelectSaveSlot : MonoBehaviour
{
    public GameObject creat;
    public TextMeshProUGUI[] slotText;
    public TextMeshProUGUI newPlayerName;
    
    bool[] savefile = new bool[3]; // 0 1 2

    void Start()
    {
        for (int _count = 0; _count < 3; _count++)
        {
            if(File.Exists(DataManager.instance.path + $"{_count}" ))
            {
                savefile[_count] = true;
                DataManager.instance.nowSlot = _count;
                DataManager.instance.LoadData();
                slotText[_count].text = DataManager.instance.play_data.UserName; // 버튼에 닉네임 표시
            }
            else
            {
                slotText[_count].text = "비어있음";
            }
        }
        print(DataManager.instance.path);
        DataManager.instance.DataClear(); // 텍스트 출력을 위해 불러온 데이터 초기화
    }

    public void Slot(int number) // 게임 슬롯
    {
        DataManager.instance.nowSlot = number;
        if (savefile[number]) // bool 배열에서 현재 슬롯이 true = 데이터가 존재하면
        {
            DataManager.instance.LoadData();
            GoGame();

        }
        else
        {
            Creat();
        }

    }
    public void Creat()
    {
        creat.gameObject.SetActive(true);
    }
    public void GoGame()
    {
        if (!savefile[DataManager.instance.nowSlot])
        {
            DataManager.instance.play_data.UserName = newPlayerName.text;
            DataManager.instance.SaveData();
        }
        SceneManager.LoadScene("SampleScene_Kys");
    }

}
