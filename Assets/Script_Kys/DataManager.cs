using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public User_Data play_data = new User_Data();

    public string path;//���� ���
    public int nowSlot; //���� ��ȣ

    private void Awake()
    {
        #region �̱���
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        #endregion

        path = Application.persistentDataPath + "/save"; // ��� ����
    }

    void Start()
    {

    }

    public void SaveData()
    {
        string data = JsonUtility.ToJson(play_data);
        File.WriteAllText(path + nowSlot, data);
    }
    public void LoadData()
    {
        string data = File.ReadAllText(path + nowSlot);
        play_data = JsonUtility.FromJson<User_Data>(data);
    }

    public void DataClear()
    {
        nowSlot = -1;
        play_data = new User_Data();
    }

}