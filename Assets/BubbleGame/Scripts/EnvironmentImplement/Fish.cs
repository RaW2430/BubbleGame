using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour, RandomParameter
{
    public float speed;
    private Vector3 originPos;
    private PlayerController2D player;
    public bool isAtached = false;
    public bool isTriggered = false;
    private Vector3 lastPosition;

    private void Awake()
    {
        originPos = transform.position;
        lastPosition = transform.position;
    }

    private void Update()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerController2D>();
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

        if (isAtached)
        {
            if (!player.isFreezed)
            {
                isAtached = false;
            }
            else player.transform.position = transform.position;
        }
        if (transform.position.y < player.transform.position.y - 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isTriggered || player == null) return;
        Debug.Log("Fish OnTriggerEnter2D");
        player.FreezePlayer();
        isAtached = true;
        isTriggered = true;
    }

    void RandomParameter.GenerateRandomParameter()
    {
        speed = UnityEngine.Random.Range(0.5f, 8f);
    }
}
