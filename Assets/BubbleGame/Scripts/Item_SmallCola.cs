using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_SmallCola : MonoBehaviour
{
    public float speedMultiplier = 3f;
    public float speedUpTime = 5f;
    public float invincibleTime = 5f;
    // ��������ײ����봥����ʱ����
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // �����ײ��ı�ǩ�Ƿ�Ϊ "Player"
        if (hitInfo.CompareTag("Player"))
        {
            // ��ȡ PlayerAttributes �ű�
            PlayerAttributes playerAttributes = hitInfo.GetComponent<PlayerAttributes>();
            if (playerAttributes != null)
            {
                // �����޵�
                playerAttributes.ActivateInvincibility();
                // ��������
                playerAttributes.speedUpTime = speedUpTime;
                playerAttributes.speedMultiplier = speedMultiplier;
                playerAttributes.ActivateSpeedBoost();
            }

            // ���ٵ�ǰ����
            Destroy(gameObject);
        }
    }
}




