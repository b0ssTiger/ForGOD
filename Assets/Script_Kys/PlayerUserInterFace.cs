using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUserInterFace : MonoBehaviour
{
    [SerializeField]
    Slider HPbar;
    [SerializeField]
    TextMeshProUGUI _cetHP;
    [SerializeField]
    TextMeshProUGUI _maxHP;

    [SerializeField]
    TextMeshProUGUI _Player_name;

    DataManager Player;

    private void Start()
    {
        Player = DataManager.instance;
    }

    private void LateUpdate()
    {
        if (Player != null)
        {
            _cetHP.text = Player.play_data.Curhp.ToString();
            _maxHP.text = Player.play_data.Maxhp.ToString();
            _Player_name.text = Player.play_data.UserName.ToString();
            HPbar.value = Player.play_data.Curhp / Player.play_data.Maxhp;
        }
    }



}
