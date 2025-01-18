using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaUrchin : MonoBehaviour
{
    public int damage = 10;
    private PlayerAttributes playertest;
    bool isTriggered = false;
    private void Awake()
    {
        playertest = FindObjectOfType<PlayerAttributes>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        playertest.TakeDamage(damage);
    }
    
    private void Update()
    {
        if(isTriggered) return;
        isTriggered = true;
        
        if (playertest == null)
        {
            playertest = FindObjectOfType<PlayerAttributes>();
        }
        if(playertest == null)
        {
            Destroy(gameObject);
            return;
        }
        if(transform.position.y < playertest.transform.position.y - 10)
        {
            Destroy(gameObject);
        }
    }
}
