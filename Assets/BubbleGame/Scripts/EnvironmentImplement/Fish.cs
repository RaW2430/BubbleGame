using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public float speed;
    private Vector3 originPos;
    private PlayerController2D player;
    public bool isAtached = false;
    public bool isTriggered = false;
    private void Awake()
    {
        originPos = transform.position;
        
    }

    private void Update()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerController2D>();
        }   
        transform.position = new Vector3(originPos.x + Mathf.Sin(Time.time * speed), originPos.y, originPos.z);
        if (isAtached)
        {
            if (!player.isFreezed)
            {
                isAtached = false;
            }
            else player.transform.position=transform.position;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isTriggered || player == null ) return;
        Debug.Log("Fish OnTriggerEnter2D");
        player.FreezePlayer();
        isAtached = true;
        isTriggered = true;
    }

}
