using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapEffect : MonoBehaviour
{
    public GameObject hurtPointPrefab; // Ԥ����
    private bool hasTriggered = false;
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
        PlayerAttributes playerAttributes = other.GetComponent<PlayerAttributes>();
        if (!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true;
            if(playerAttributes != null)
            {
                if(playerAttributes.isInvincible)
                {
                    Debug.Log("Player is invincible!");
                    return;
                }   
            }   
            Vector3 triggerPosition = other.ClosestPoint(transform.position); // ��ȡ����λ��
            Instantiate(hurtPointPrefab, triggerPosition, Quaternion.identity); // ����HurtPoint����
        }
    }
}
