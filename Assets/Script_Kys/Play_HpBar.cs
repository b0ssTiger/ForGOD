using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;

public class Play_HpBar : MonoBehaviour
{
    public Slider Hpbar;

    private float curHealth;
    private float maxHealth;

    public DataManager _Player;

    public void SetHp()
    {
        curHealth = _Player.play_data.Curhp;
        maxHealth = _Player.play_data.Maxhp;
    }

    public void CheckHp()
    {
        if(Hpbar != null)
        {
            Hpbar.value = curHealth / maxHealth;
        }
    }
    

}
