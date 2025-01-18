using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttributes : MonoBehaviour
{
    public float health = 100f;
    public float extraAcceleration = 0f;
<<<<<<< HEAD
    public TextMeshProUGUI altitudeText;
    public float invincibleTime = 5f;
    public float speedUpTime = 5f;
    public float speedMultiplier = 2f;
    public bool isInvincible = false;
    private float initAltitude = -10984f;
=======
    public bool shield = false;
    public TextMeshProUGUI altitudeText; // å¼•ç”¨UI Textç»„ä»¶
    private float initAltitude = -10984f; 
>>>>>>> d09ce8c0adfa8fdfbb452e031a068ae5247c9f29
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
        // æ ¹æ®å¥åº·å€¼è§¦å‘ä¸åŒçš„åŠ¨ç”»
        UpdateHealthAnimation();

        // æ›´æ–°æµ·æ‹”é«˜åº¦æ–‡æœ¬
        UpdateAltitudeText();

        // æ£€æŸ¥å¥åº·å€¼æ˜¯å¦å°äº0
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
<<<<<<< HEAD
            // Èç¹ûÎŞµĞ×´Ì¬£¬²»ÊÜÉËº¦
            return;
=======
            // å¦‚æœæœ‰æŠ¤ç›¾ï¼Œå‡å°‘ä¼¤å®³
            damage *= 0.5f;
>>>>>>> d09ce8c0adfa8fdfbb452e031a068ae5247c9f29
        }

        health -= damage;

        if (health < 0)
        {
            Die();
        }
    }
    //ÎŞµĞÊÂ¼ş
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
            spriteRenderer.enabled = !spriteRenderer.enabled; // ÇĞ»»¿É¼ûĞÔ
            yield return new WaitForSeconds(0.1f); // Ã¿0.1ÃëÇĞ»»Ò»´Î
            elapsedTime += 0.1f;
        }
        spriteRenderer.enabled = true; // È·±£ÔÚ½áÊøÊ±¿É¼û
        isInvincible = false;
    }

    //¼ÓËÙÊÂ¼ş
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
    //ËÀÍöÊÂ¼ş
    void Die()
    {
        // è§¦å‘æ­»äº¡UI
        //UIManager.Instance.ShowDeathUI();
        // é”€æ¯å¯¹è±¡
        Destroy(gameObject);
    }
}




