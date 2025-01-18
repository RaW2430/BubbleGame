using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private PlayerController2D player;
    
    void Awake()
    {
        player = FindObjectOfType<PlayerController2D>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Rock OnTriggerEnter2D");
        player.FreezePlayer();
        player.transform.position = transform.position;
    }
}
