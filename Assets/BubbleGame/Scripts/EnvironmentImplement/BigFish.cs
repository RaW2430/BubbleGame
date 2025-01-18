using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigFish : MonoBehaviour
{
    public int damage = 10;
    private Playertest playertest;
    public float speed;
    private Vector3 originPos;

    
    //有可能多次触发，所以要在这里判断是否已经触发过
    private bool isTriggered = false;
    
    private void Awake()
    {
        playertest = FindObjectOfType<Playertest>();
        originPos = transform.position;
    }

    private void Update()
    {
        transform.position = new Vector3(originPos.x + Mathf.Sin(Time.time * speed), originPos.y, originPos.z);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isTriggered) return;
        playertest.ReduceHp(damage);
        isTriggered = true;
    }
}
