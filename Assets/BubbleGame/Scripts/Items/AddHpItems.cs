using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHpItems : MonoBehaviour
{
    private PlayerAttributes player;
    public int AddHpValue = 10;
    private void Awake()
    {
        player = FindObjectOfType<PlayerAttributes>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("AddHpItems OnTriggerEnter2D");
        player.AddHealth(AddHpValue);
        Destroy(gameObject);
    }
}
