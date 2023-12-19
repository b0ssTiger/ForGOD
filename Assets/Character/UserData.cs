using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UserData : MonoBehaviour
{
    public string UserName = "cola";
    public float Maxhp = 100f;
    public float Curhp = 100f;
    public int atk = 10;

    public Animator animator;    
    public Image Hpimage;

    public void Start()
    {
        
        Maxhp = Curhp;
        
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
        float fillAmount = Curhp / Maxhp;
        Hpimage.fillAmount = fillAmount; 
    }

   
    public void TakeDamage(float damage)
    {
        
        Curhp -= damage;
        Curhp = Mathf.Clamp(Curhp, 0f, Maxhp);
        Updatehp();
        
        if (Curhp <= 0f) 
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
