using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class LoginUI : MonoBehaviour
{
    public TMP_InputField inputField_ID;
    public TMP_InputField inputField_Password;
    public Button Btn_Login;

    private string _user = "user"; //아이디
    private string _password = "1234"; // 비번

    public void LoginButton()
    {
        if(inputField_ID.text == _user && inputField_Password.text == _password)
        {
            SceneManager.LoadScene("SampleScene_Kys");
        }
        else
        {
            Debug.LogError("아이디 혹은 비밀번호가 틀렸습니다.");
        }
    }

}

