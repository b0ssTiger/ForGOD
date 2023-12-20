using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UserData : MonoBehaviour
{

    public UserStat Player_Stats = new UserStat();

    public Animator animator;    
    public Image Hpimage;

    public Slider PlayerInterface_Hpbar;

    public void Start()
    {

        Player_Stats.Maxhp = Player_Stats.Curhp;
        
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(50f);
        }

        PlayerInterface_Hpbar.value = Player_Stats.Curhp / Player_Stats.Maxhp;
    }

    public void Updatehp()
    {
        float fillAmount = Player_Stats.Curhp / Player_Stats.Maxhp;
        Hpimage.fillAmount = fillAmount; 
    }

   
    public void TakeDamage(float damage)
    {
        animator.SetTrigger("Damage");
        Player_Stats.Curhp -= damage;
        Player_Stats.Curhp = Mathf.Clamp(Player_Stats.Curhp, 0f, Player_Stats.Maxhp);
        Updatehp();
        
        if (Player_Stats.Curhp <= 0f) 
        {
            UserDie();
        }
    } 

    public void UserDie()
    {
        animator.SetTrigger("Dead");
        // 플레이어 사망 이후 UI 로드 (사망정보창, 부활)
    }

    public class UserStat
    {
        public string UserName = "cola";
        public float Maxhp = 100f;
        public float Curhp = 100f;
        public int atk = 10;
    }
}
