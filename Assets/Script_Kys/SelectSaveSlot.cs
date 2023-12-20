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
                slotText[_count].text = DataManager.instance.play_data.UserName; // ��ư�� �г��� ǥ��
            }
            else
            {
                slotText[_count].text = "�������";
            }
        }
        print(DataManager.instance.path);
        DataManager.instance.DataClear(); // �ؽ�Ʈ ����� ���� �ҷ��� ������ �ʱ�ȭ
    }

    public void Slot(int number) // ���� ����
    {
        DataManager.instance.nowSlot = number;
        if (savefile[number]) // bool �迭���� ���� ������ true = �����Ͱ� �����ϸ�
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
