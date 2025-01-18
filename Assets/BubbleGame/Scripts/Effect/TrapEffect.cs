using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapEffect : MonoBehaviour
{
    public GameObject hurtPointPrefab; // 预制体

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 triggerPosition = other.ClosestPoint(transform.position); // 获取触碰位置
            Instantiate(hurtPointPrefab, triggerPosition, Quaternion.identity); // 生成HurtPoint对象
        }
    }
}
