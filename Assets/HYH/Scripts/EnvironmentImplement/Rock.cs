using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private Playertest player;
    
    void Awake()
    {
        player = FindObjectOfType<Playertest>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Rock OnTriggerEnter2D");
        player.acceleration = new Vector3(0,0,0);
        player.velocity = new Vector3(0,0,0);
        player.rb.transform.parent = transform;
    }
}
