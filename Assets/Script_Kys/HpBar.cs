using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Slider Hpbar;

    private float curHealth;
    private float maxHealth;

    DataManager play_HP = new DataManager();

    public void SetHp()
    {
        curHealth = play_HP.play_data.Curhp;
        maxHealth = play_HP.play_data.Maxhp;
    }

    public void CheckHp()
    {
        if(Hpbar != null)
        {
            Hpbar.value = curHealth / maxHealth;
        }
    }
    

}
