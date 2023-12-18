using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Items : MonoBehaviour
{
    [SerializeField] private ItemSO itemSO;

    private void Awake()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if( sprite != null )
        {
            sprite.sprite = itemSO.icon;
        }
    }
}
