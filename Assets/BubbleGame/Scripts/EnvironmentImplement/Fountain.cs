
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fountain : MonoBehaviour
{
    private PlayerController2D player;

    public float accelerationBias = 10f;
    
    void Awake()
    {
        player = FindObjectOfType<PlayerController2D>();
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
