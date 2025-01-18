using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanCurrent : MonoBehaviour
{
    private PlayerController2D player;
    
    void Awake()
    {
        player = FindObjectOfType<PlayerController2D>();
    }
    
    public float aceelerationBias = 10f;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (player.isFreezed) return;
        player.rb.AddForce(Vector2.right * aceelerationBias);
    }
}
