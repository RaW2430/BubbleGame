using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    //private Playertest player;
    public int hpCheckValue = 50;
    bool isTriggered = false;
    private void Awake()
    {
        //player = FindObjectOfType<Playertest>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isTriggered) return;
        isTriggered = true;
        PlayerAttributes playerAttributes = other.GetComponent<PlayerAttributes>();
        Debug.Log("CheckPoint OnTriggerEnter2D");
        //player.ReduceHp(hpCheckValue);
        playerAttributes.TakeDamage(hpCheckValue);
        Destroy(gameObject,5f);
    }


}
