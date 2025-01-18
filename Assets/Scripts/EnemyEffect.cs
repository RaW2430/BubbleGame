using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEffect : MonoBehaviour
{
    public float health = 100f;
    public float damage = 10f;
    public Color highlightColor = Color.red;
    private Color originalColor;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Weapon"))
        {
            TakeDamage(damage);
            Highlight();
        }
    }

    void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Highlight()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = highlightColor;
            Invoke("ResetColor", 0.2f); // 0.2秒后恢复原色
        }
    }

    void ResetColor()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = originalColor;
        }
    }

    void Die()
    {
        // 播放死亡动画
        if (animator != null)
        {
            animator.SetBool("IsDead", true);
            // 等待动画播放完毕后销毁对象
            StartCoroutine(DestroyAfterAnimation());
        }
        else
        {
            // 如果没有动画机，直接销毁对象
            //Destroy(gameObject);
        }
    }

    IEnumerator DestroyAfterAnimation()
    {
        // 获取当前动画状态信息
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        // 等待当前动画播放完毕
        yield return new WaitForSeconds(stateInfo.length);
        // 销毁对象
        Destroy(gameObject);
    }
}


