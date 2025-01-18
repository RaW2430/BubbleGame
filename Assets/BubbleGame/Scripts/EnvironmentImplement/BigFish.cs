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
    private Vector3 lastPosition;

    //有可能多次触发，所以要在这里判断是否已经触发过
    private bool isTriggered = false;

    private void Awake()
    {
        player = GameObject.Find("Player");
        originPos = transform.position;
        lastPosition = transform.position;
    }

    private void Update()
    {
        if (playerAttributes == null)
        {
            playerAttributes = FindObjectOfType<PlayerAttributes>();
        }
        if (playerAttributes == null)
        {
            //说明没找到
            Destroy(gameObject);
            return;
        }
        

        // 更新位置
        transform.position = new Vector3(originPos.x + 10 * Mathf.Sin(Time.time * speed), originPos.y, originPos.z);

        // 计算速度方向
        Vector3 velocity = (transform.position - lastPosition) / Time.deltaTime;
        lastPosition = transform.position;

        // 判断速度方向并旋转
        if (velocity.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        
        if (transform.position.y < playerAttributes.transform.position.y - 10)
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
