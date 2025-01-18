using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttributes : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;
    public float extraAcceleration = 0f;
    public TextMeshProUGUI altitudeText;
    public float invincibleTime = 5f;
    public float hurtTime = 3f;
    public float speedUpTime = 5f;
    public float speedMultiplier = 2f;
    public bool isInvincible = false;
    public bool isDead = false;
    public bool isHurt = false;
    public GameObject gameManager;
    private float initAltitude = -10984f;
    private Animator animator;
    private float offset;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private int healthStage = 2;
    

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
        UpdateHealthAnimation();
        UpdateAltitudeText();

        if (!isDead && health <= 0)
        {
            isDead = true;
            animator.SetBool("IsDead", true); // 播放死亡动画
            rb.velocity = Vector3.zero;
            //Debug.Log("Am I dead?");
            StartCoroutine(DieCoroutine());
        }
    }

    void UpdateHealthAnimation()
    {
        if (animator != null)
        {
            if (health > 0 && health < 10)
            {
                healthStage = 0;
            }
            else if (health >= 10 && health < 30)
            {
                healthStage = 1;
            }
            else if (health >= 30 && health < 60)
            {
                healthStage = 2;
            }
            else if (health >= 60 && health < 90)
            {
                healthStage = 3;
            }
            else if (health >= 90)
            {
                healthStage = 4;
            }
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
            // 如果无敌状态，不受伤害
            return;
        }

        health -= damage;

        if (health <= 0)
        {
            //StartCoroutine(DieCoroutine());
        }
        else
        {
            StartCoroutine(HurtCoroutine());
        }
    }

    public void AddHealth(float value)
    {
        health = Mathf.Min(health + value, maxHealth);
    }
    //受伤事件
    private IEnumerator HurtCoroutine()
    {
        isHurt = true;
        animator.SetBool("IsHurt", true); // 播放受伤动画
        yield return new WaitForSeconds(hurtTime); // 受伤状态持续5秒
        animator.SetBool("IsHurt", false); // 结束受伤动画
        isHurt = false;
    }
    //无敌事件
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
            spriteRenderer.enabled = !spriteRenderer.enabled; // 切换可见性
            yield return new WaitForSeconds(0.1f); // 每0.1秒切换一次
            elapsedTime += 0.1f;
        }
        spriteRenderer.enabled = true; // 确保在结束时可见
        isInvincible = false;
    }

    //加速事件
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

    //死亡事件
    private IEnumerator DieCoroutine()
    {
        if (animator != null)
        {
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length); // 等待动画播放完毕
        }
        RestartEvent();
        //Destroy(gameObject); // 销毁Player对象
    }
    void RestartEvent()
    {
        gameManager.GetComponent<UIEvent>().RestartGame();
    }
}


