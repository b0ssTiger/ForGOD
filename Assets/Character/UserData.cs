using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;


public class UserData : MonoBehaviour
{

    public UserStat Player_Stats = new UserStat();
    public Animator animator;
    public Image Hpimage;
    DataManager _Player;


    public void Start()
    {

        _Player = DataManager.instance;
        Player_Stats.Maxhp = Player_Stats.Curhp;
        
    }

    void Update()
    {
        
       
       
    }

    public void Updatehp()
    {
        float fillAmount = _Player.play_data.Curhp / _Player.play_data.Maxhp;
        Hpimage.fillAmount = fillAmount; 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            TakeDamage(10);
        }
    }


            public void TakeDamage(float damage)
    {
        animator.SetTrigger("Damage");
        _Player.play_data.Curhp -= damage;
        _Player.play_data.Curhp = Mathf.Clamp(_Player.play_data.Curhp, 0f, _Player.play_data.Maxhp);
        Updatehp();
        
        if (_Player.play_data.Curhp <= 0f) 
        {
            UserDie();
        }
    } 

    public void UserDie()
    {
        animator.SetTrigger("Dead");
        Invoke("asd", 5f);
    }

    public class UserStat
    {
        public string UserName = "cola";
        public float Maxhp = 100f;
        public float Curhp = 100f;
        public int atk = 10;
    }

    void asd()
    {
        SceneManager.LoadScene("FirstGameScene");
    }
}
