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
            Invoke("ResetColor", 0.2f); // 0.2���ָ�ԭɫ
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
        // ������������
        if (animator != null)
        {
            animator.SetBool("IsDead", true);
            // �ȴ�����������Ϻ����ٶ���
            StartCoroutine(DestroyAfterAnimation());
        }
        else
        {
            // ���û�ж�������ֱ�����ٶ���
            //Destroy(gameObject);
        }
    }

    IEnumerator DestroyAfterAnimation()
    {
        // ��ȡ��ǰ����״̬��Ϣ
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        // �ȴ���ǰ�����������
        yield return new WaitForSeconds(stateInfo.length);
        // ���ٶ���
        Destroy(gameObject);
    }
}


