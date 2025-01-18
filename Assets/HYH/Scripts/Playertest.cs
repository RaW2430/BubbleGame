using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playertest : MonoBehaviour
{

    public Rigidbody2D rb;
    public Vector3 acceleration = new Vector3(0,1,0);
    public Vector3 velocity = new Vector3();
    public int hp;
    public int hpMax;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d"))
        {
            velocity.x = 1;
        }
        else if (Input.GetKey("a"))
        {
            velocity.x = -1;
        }
        else if(acceleration.x==0)velocity.x = 0;
        velocity += acceleration * Time.deltaTime;
        
        rb.velocity = velocity;
        
    }
    
    public void AddHp(int hpBias)
    {
        hp += hpBias;
        if (hp > hpMax)
        {
            hp = hpMax;
        }
    }
    public void ReduceHp(int hpBias)
    {
        hp -= hpBias;
        if (hp <= 0)
        {
            hp = 0;
        }
    }
    
}
