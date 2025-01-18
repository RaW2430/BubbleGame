using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaUrchin : MonoBehaviour
{
    public int damage = 10;
    private Playertest playertest;

    private void Awake()
    {
        playertest = FindObjectOfType<Playertest>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        playertest.ReduceHp(damage);
    }
}
