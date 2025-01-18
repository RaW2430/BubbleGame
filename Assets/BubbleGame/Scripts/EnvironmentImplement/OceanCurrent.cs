using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanCurrent : MonoBehaviour
{
    private Playertest player;
    
    void Awake()
    {
        player = FindObjectOfType<Playertest>();
    }
    
    public float aceelerationBias = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OceanCurrent OnTriggerStay2D");
        player.acceleration+= new Vector3(aceelerationBias,0,0);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("OceanCurrent OnTriggerExit2D");
        player.acceleration-= new Vector3(aceelerationBias,0,0);
    }
}
