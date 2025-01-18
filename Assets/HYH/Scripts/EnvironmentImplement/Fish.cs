using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public float speed;
    private Vector3 originPos;
    private Playertest player;
    public bool isAtached = false;
    public bool isTriggered = false;
    private void Awake()
    {
        originPos = transform.position;
        player = FindObjectOfType<Playertest>();
    }

    private void Update()
    {
        transform.position = new Vector3(originPos.x + Mathf.Sin(Time.time * speed), originPos.y, originPos.z);
        if (isAtached)
        {
            player.rb.position = transform.position;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isTriggered) return;
        Debug.Log("Fish OnTriggerEnter2D");
        player.acceleration = new Vector3(0,0,0);
        player.velocity = new Vector3(0,0,0);
        isAtached = true;
        isTriggered = true;
    }
    public void Detach()
    {
        isAtached = false;
    }
}
