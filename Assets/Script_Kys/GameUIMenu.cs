using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIMenu : MonoBehaviour
{
    public Animator animator;

    private void OnEnable()
    {
        animator.SetTrigger("Open");
    }
}
