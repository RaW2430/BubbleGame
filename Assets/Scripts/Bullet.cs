using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float range = 15f; // 子弹射程
    private Rigidbody2D rb;
    private Vector2 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        startPosition = rb.position; // 记录子弹初始位置
    }

    // Update is called once per frame
    void Update()
    {
        // 检查子弹是否超出射程
        if (Vector2.Distance(startPosition, rb.position) >= range)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        Destroy(gameObject);
    }
}

