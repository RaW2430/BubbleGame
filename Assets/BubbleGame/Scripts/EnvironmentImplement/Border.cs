using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    private PlayerAttributes player;
    
    void Awake()
    {
        player = FindObjectOfType<PlayerAttributes>();
    }
    
    private void Update()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerAttributes>();
        }
        if(player == null)
        {
            Destroy(gameObject);
            return;
        }
        var pos = transform.position;
        pos.y = player.transform.position.y;
        transform.position = pos;
    }
}
