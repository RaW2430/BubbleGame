using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static ItemEffect;

public class PlayerAttributes : MonoBehaviour
{
    public float health = 60f;
    private float initHealth;
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
    public float currentAltitude;
    public GameObject gameManager;
    private float initAltitude = -10984f;
    private Animator animator;
    private float offset;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private int healthStage = 2;
    private Vector3 originalScale;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        offset = transform.position.y;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalScale = transform.localScale; // 保存原始scale
        initHealth = health;
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
            rb.bodyType = RigidbodyType2D.Static;
            //Debug.Log("Am I dead?");
            StartCoroutine(DieCoroutine());
        }
        // 根据health的大小动态设置localScale，形变倍率为(0.3，1.5)
        float scaleMultiplier = Mathf.Lerp(0.3f, 1.5f, health / maxHealth);
        transform.localScale = originalScale * scaleMultiplier;

        if (currentAltitude >= 0)
        {
            
        }
    }

    void UpdateHealthAnimation()
    {
        if (animator != null)
        {
            CircleCollider2D circleCollider = GetComponent<CircleCollider2D>();
            if (circleCollider != null)
            {
                if (health > 0 && health < 25)
                {
                    healthStage = 0;
                    //circleCollider.radius = 0.16f; // 修改圆形碰撞体的倍率
                }
                else if (health >= 25 && health < 50)
                {
                    healthStage = 1;
                    //circleCollider.radius = 0.32f; // 修改圆形碰撞体的倍率
                }
                else if (health >= 50 && health < 75)
                {
                    healthStage = 2;
                    //circleCollider.radius = 0.47f; // 修改圆形碰撞体的倍率
                }
                else if (health >= 75)
                {
                    healthStage = 3;
                    //circleCollider.radius = 0.62f; // 修改圆形碰撞体的倍率
                }
                animator.SetInteger("HealthStage", healthStage);
            }
        }
    }

    void UpdateAltitudeText()
    {
        if (altitudeText != null)
        {
            float newAltitude = transform.position.y + initAltitude - offset;
            altitudeText.text = "Altitude: " + newAltitude.ToString("F2") + "m";
            currentAltitude = newAltitude;  
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
        if(!isDead && !isHurt && health > 0)
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
        yield return new WaitForSeconds(hurtTime); // 受伤状态持续
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
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length * 0f); // 等待动画播放完毕
            //yield return new WaitForSeconds(10f); // 等待动画播放完毕
        }
        RestartEvent();
        //Destroy(gameObject); // 销毁Player对象
        HidePlayer();
    }
    void HidePlayer()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false; // 禁用渲染
        }
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = false; // 禁用碰撞
        }
        // 你可以在这里禁用其他组件，例如移动脚本等
    }
    void RestartEvent()
    {
        gameManager.GetComponent<UIEvent>().RestartGame();
    }
}


