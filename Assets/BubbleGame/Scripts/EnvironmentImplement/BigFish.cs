using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class BigFish : MonoBehaviour
{
    public int damage = 10;
    public float speed;
    private Vector3 originPos;
    private GameObject player;
    private PlayerAttributes playerAttributes;

    
    //有可能多次触发，所以要在这里判断是否已经触发过
    private bool isTriggered = false;
    
    private void Awake()
    {
        player = GameObject.Find("Player"); 
        originPos = transform.position;
    }

    private void Update()
    {
        if (player == null) return;
        if (playerAttributes == null)
        {
            playerAttributes = FindObjectOfType<PlayerAttributes>();
        }
        transform.position = new Vector3(originPos.x + 10*Mathf.Sin(Time.time * speed), originPos.y, originPos.z);
        if(transform.position.y < playerAttributes.transform.position.y - 10)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isTriggered) return;
        playerAttributes.TakeDamage(damage);
        isTriggered = true;
    }
}
