using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttributes : MonoBehaviour
{
    public float health = 100f;
    public float extraAcceleration = 0f;
    public TextMeshProUGUI altitudeText;
    public float invincibleTime = 5f;
    public float speedUpTime = 5f;
    public float speedMultiplier = 2f;
    public bool isInvincible = false;
    private float initAltitude = -10984f;
    private Animator animator;
    private float offset;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        offset = transform.position.y;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        if (isInvincible)
        {
            // ����޵�״̬�������˺�
            return;
        }

        health -= damage;

        if (health < 0)
        {
            Die();
        }
    }
    //�޵��¼�
    public void ActivateInvincibility()
    {
        if (!isInvincible)
        {
            StartCoroutine(InvincibilityCoroutine());
        }
    }

    private IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        float elapsedTime = 0f;
        while (elapsedTime < invincibleTime)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled; // �л��ɼ���
            yield return new WaitForSeconds(0.1f); // ÿ0.1���л�һ��
            elapsedTime += 0.1f;
        }
        spriteRenderer.enabled = true; // ȷ���ڽ���ʱ�ɼ�
        isInvincible = false;
    }

    //�����¼�
    public void ActivateSpeedBoost()
    {
        StartCoroutine(SpeedBoostCoroutine());
    }

    private IEnumerator SpeedBoostCoroutine()
    {
        float originalSpeed = rb.velocity.magnitude;
        rb.velocity *= speedMultiplier;
        yield return new WaitForSeconds(speedUpTime);
        rb.velocity = rb.velocity.normalized * originalSpeed;
    }
    //�����¼�
    void Die()
    {
        // ��������UI
        //UIManager.Instance.ShowDeathUI();
        // ���ٶ���
        Destroy(gameObject);
    }
}




