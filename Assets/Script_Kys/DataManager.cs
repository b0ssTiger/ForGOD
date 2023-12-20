using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using static UserData;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public UserStat play_data = new UserStat();

    public string path;//파일 경로
    public int nowSlot; //슬롯 번호

    private void Awake()
    {
        #region 싱글톤
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

        path = Application.dataPath + "/PlayerDate"; // 경로 지정
    }

    void Start()
    {

    }

    public void SaveData()
    {
        string data = JsonUtility.ToJson(play_data,true);
        File.WriteAllText(path + nowSlot, data);
    }
    public void LoadData()
    {
        string data = File.ReadAllText(path + nowSlot);
        play_data = JsonUtility.FromJson<UserStat>(data);
    }

    public void DataClear()
    {
        nowSlot = -1;
        play_data = new UserStat();
    }

}
