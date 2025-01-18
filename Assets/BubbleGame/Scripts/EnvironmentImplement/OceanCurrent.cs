using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanCurrent : MonoBehaviour,RandomParameter
{
    private PlayerController2D player;
    
    void Awake()
    {
        player = FindObjectOfType<PlayerController2D>();
    }
    
    public float accelerationBias = 10f;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (player.isFreezed) return;
        player.rb.AddForce(transform.right * accelerationBias);
    }

    void RandomParameter.GenerateRandomParameter()
    {
        //根据位置调整朝向
        if (transform.position.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void Update()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerController2D>();
        }
        if(transform.position.y < player.transform.position.y - 10)
        {
            Destroy(gameObject);
        }
    }
}
