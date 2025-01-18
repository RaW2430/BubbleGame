using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour,RandomParameter
{
    public float speed;
    private Vector3 originPos;
    private PlayerController2D player;
    public bool isAtached = false;
    public bool isTriggered = false;
    private GameObject playerObject;
    private void Awake()
    {
        originPos = transform.position;
        playerObject = GameObject.Find("Player");
    }

    private void Update()
    {
        if ( playerObject == null) return;
        if (player == null)
        {
            player = FindObjectOfType<PlayerController2D>();
        }   
        transform.position = new Vector3(originPos.x + 10*Mathf.Sin(Time.time * speed), originPos.y, originPos.z);
        if (isAtached)
        {
            if (!player.isFreezed)
            {
                isAtached = false;
            }
            else player.transform.position=transform.position;
        }
        if(transform.position.y < player.transform.position.y - 10)
        {
            Destroy(gameObject);
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
    
    void RandomParameter.GenerateRandomParameter()
    {
        speed = UnityEngine.Random.Range(0.5f, 1.5f);
    }

}
