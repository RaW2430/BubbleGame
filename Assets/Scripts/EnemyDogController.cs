using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDogController : MonoBehaviour
{
    public float speed = 50f;
    public float jumpForce = 300f;
    public float detecionRange = 10f;  // distance from player to start chasing
    public float loseTargetTime = 3f;  // distance from player to stop chasing    
    public Transform player;
    public Animator animator;
    private bool isChasing = false;
    private float loseTargetCounter = 0f;
    private Rigidbody2D rb;
    private bool isGrounded = true;
    private Vector3 initialScale;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialScale = transform.localScale; // ��¼��ʼ�� localScale
        StartCoroutine(JumpRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        if (distance < detecionRange)
        {
            isChasing = true;
            animator.SetBool("IsChasing", true);
            //Debug.Log("Player detected");
        }
        else
        {
            if (isChasing)
            {
                loseTargetCounter += Time.deltaTime;
                if (loseTargetCounter >= loseTargetTime)
                {
                    isChasing = false;
                    animator.SetBool("IsChasing", false);
                    loseTargetCounter = 0f;
                }
            }
        }

        // ת�����
        if (player.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-Mathf.Abs(initialScale.x), initialScale.y, initialScale.z); // �����ұ�
        }
        else
        {
            transform.localScale = new Vector3(Mathf.Abs(initialScale.x), initialScale.y, initialScale.z); // �������
        }
    }

    void FixedUpdate()
    {
        if (isChasing)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = new Vector2(direction.x * speed * Time.deltaTime, rb.velocity.y);
            //Debug.Log(rb.velocity);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y); // ͣ��ԭ�أ������κ�ˮƽ�ƶ�
        }
    }

    IEnumerator JumpRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0, 5));
            if (isGrounded)
            {
                rb.AddForce(new Vector2(0, jumpForce));
                isGrounded = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}

