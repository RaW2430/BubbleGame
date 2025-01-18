using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Shield : MonoBehaviour
{
    public float invincibleTime = 10f;
    // 当其他碰撞体进入触发器时调用
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // 检查碰撞体的标签是否为 "Player"
        if (hitInfo.CompareTag("Player"))
        {
            // 获取 PlayerAttributes 脚本
            PlayerAttributes playerAttributes = hitInfo.GetComponent<PlayerAttributes>();
            if (playerAttributes != null)
            {
                // 触发无敌
                playerAttributes.invincibleTime = invincibleTime;
                playerAttributes.ActivateInvincibility();
            }

            // 销毁当前物体
            Destroy(gameObject);
        }
    }
}




