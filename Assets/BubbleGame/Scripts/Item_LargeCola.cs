using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_LargeCola : MonoBehaviour
{
    public float speedMultiplier = 6f;
    public float speedUpTime = 10f;
    public float invincibleTime = 10f;
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




