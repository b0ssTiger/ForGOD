using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;

public class Play_HpBar : MonoBehaviour
{
    [SerializeField]
    Slider Hpbar;

    DataManager _Player;

    public void Start()
    {
        _Player = DataManager.instance;
    }

   

    public void LateUpdate()
    {
        if(Hpbar != null)
        {
            Hpbar.value = _Player.play_data.Curhp / _Player.play_data.Maxhp;
        }
    }
    

}
