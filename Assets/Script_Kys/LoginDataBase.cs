using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginDataBase : MonoBehaviour
{
    public InputField inputField_ID;
    public InputField inputField_Password;
    public Button Btn_Login;


    public void LoginButtonClick()
    {
        SceneManager.LoadScene("SampleScene_Kys");
    }
}




    public class GameUserInfo
    {
        public string id { get; set; }
        public string password {get; set; }

        public string identifynumber { get; set; }
        public void User(string _id, string _pw, string _identifynumber)
        {
            this.id = _id;
            this.password = _pw;
            this.identifynumber = _identifynumber;
        }
    }
