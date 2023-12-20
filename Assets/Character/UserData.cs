using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UserData : MonoBehaviour
{

    public UserStat Player_Stat = new UserStat();

    public Animator animator;    
    public Image Hpimage;

    public void Start()
    {

        Player_Stat.Maxhp = Player_Stat.Curhp;
        
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(50f);
        }
       
    }

    public void Updatehp()
    {
        float fillAmount = Player_Stat.Curhp / Player_Stat.Maxhp;
        Hpimage.fillAmount = fillAmount; 
    }

   
    public void TakeDamage(float damage)
    {

        Player_Stat.Curhp -= damage;
        Player_Stat.Curhp = Mathf.Clamp(Player_Stat.Curhp, 0f, Player_Stat.Maxhp);
        Updatehp();
        
        if (Player_Stat.Curhp <= 0f) 
        {
            UserDie();
        }
    } 

    public void UserDie()
    {
        animator.SetTrigger("Dead");
        // 플레이어 사망 이후 UI 로드 (사망정보창, 부활)
    }
}

public class UserStat
{
    public string UserName = "cola";
    public float Maxhp = 100f;
    public float Curhp = 100f;
    public int atk = 10;
}