using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttributes : MonoBehaviour
{
    public float health = 100f;
    public float extraAcceleration = 0f;
    public bool shield = false;
    public TextMeshProUGUI altitudeText; // ����UI Text���
    private float initAltitude = -10984f; 
    private Animator animator;
    private float offset;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        offset = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        // ���ݽ���ֵ������ͬ�Ķ���
        UpdateHealthAnimation();

        // ���º��θ߶��ı�
        UpdateAltitudeText();

        // ��齡��ֵ�Ƿ�С��0
        if (health <= 0)
        {
            Die();
        }
    }

    void UpdateHealthAnimation()
    {
        if (animator != null)
        {
            int healthStage = Mathf.FloorToInt(health / 10);
            animator.SetInteger("HealthStage", healthStage);
        }
    }

    void UpdateAltitudeText()
    {
        if (altitudeText != null)
        {
            float newAltitude = transform.position.y + initAltitude - offset;  
            altitudeText.text = "Altitude: " + newAltitude.ToString("F2") + "m";
        }
    }

    public void TakeDamage(float damage)
    {
        if (shield)
        {
            // ����л��ܣ������˺�
            damage *= 0.5f;
        }

        health -= damage;

        if (health < 0)
        {
            health = 0;
        }
    }

    void Die()
    {
        // ��������UI
        //UIManager.Instance.ShowDeathUI();
        // ���ٶ���
        Destroy(gameObject);
    }
}


