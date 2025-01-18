using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    //private Playertest player;
    public int hpCheckValue = 50;
    private void Awake()
    {
        //player = FindObjectOfType<Playertest>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerAttributes playerAttributes = other.GetComponent<PlayerAttributes>();
        Debug.Log("CheckPoint OnTriggerEnter2D");
        //player.ReduceHp(hpCheckValue);
        playerAttributes.TakeDamage(hpCheckValue);
    }
}
