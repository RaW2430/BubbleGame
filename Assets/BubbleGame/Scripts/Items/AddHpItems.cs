using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHpItems : MonoBehaviour
{
    private Playertest player;
    public int AddHpValue = 10;
    private void Awake()
    {
        player = FindObjectOfType<Playertest>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("AddHpItems OnTriggerEnter2D");
        player.AddHp(AddHpValue);
        Destroy(gameObject);
    }
}
