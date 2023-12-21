using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UItest : MonoBehaviour
{
    private static UItest s_instance = null;
    bool trs;

    private void Awake()
    {
        if (trs == GameObject.Find("Player"))
        {
            if (s_instance)
            {
                DontDestroyOnLoad(this.gameObject);
                return;
            }
            s_instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
         
    }
}
