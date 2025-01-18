using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Shield : MonoBehaviour
{
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
                playerAttributes.invincibleTime = invincibleTime;
                playerAttributes.ActivateInvincibility();
            }

            // ���ٵ�ǰ����
            Destroy(gameObject);
        }
    }
}




