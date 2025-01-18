
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fountain : MonoBehaviour
{
    private PlayerController2D player;
    private GameObject playerObject;
    public float accelerationBias = 10f;
    
    void Awake()
    {
        playerObject = GameObject.Find("Player");
    }

    private void Update()
    {
        if(playerObject == null) return;    
        if (player == null)
        {
            player = FindObjectOfType<PlayerController2D>();
        }
        if(transform.position.y < player.transform.position.y - 10)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (player.isFreezed) return;
        player.upwardAcceleration+=accelerationBias;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (player.isFreezed) return;
        player.upwardAcceleration-=accelerationBias;
    }
}
