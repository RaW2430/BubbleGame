using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public float upwardAcceleration = 1f; // 向上的加速度
    public float horizontalForce = 10f; // 左右横移的力
    public float downwardForce = 10f; // 向下的力
    public float extraUpwardAcceleration = 5f; // 额外向上的加速度
    public float maxVerticalSpeed = 30f; // 最大垂直速度
    public float maxHorizontalSpeed = 10f; // 最大水平速度
    public float healthDecreaseRate = 1f; // 每秒扣血量
    private Rigidbody2D rb;
    private bool isPressingS = false;
    private bool isPressingW = false;
    private float sPressTime = 0f;
    private PlayerAttributes playerAttributes;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAttributes = GetComponent<PlayerAttributes>();
    }

    // Update is called once per frame
    void Update()
    {
        // 检测左右移动输入
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * horizontalForce);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * horizontalForce);
        }

        // 检测S键按下
        if (Input.GetKeyDown(KeyCode.S))
        {
            isPressingS = true;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            isPressingS = false;
            sPressTime = 0f; // 重置按下时间
        }

        // 检测W键按下
        if (Input.GetKeyDown(KeyCode.W))
        {
            isPressingW = true;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            isPressingW = false;
        }
    }

    // FixedUpdate is called once per physics update
    void FixedUpdate()
    {
        // 应用向上的加速度
        rb.AddForce(Vector2.up * upwardAcceleration);

        // 检测S键按下并施加向下的力
        if (isPressingS)
        {
            rb.AddForce(Vector2.down * downwardForce);
            sPressTime += Time.fixedDeltaTime;
            if (playerAttributes != null)
            {
                playerAttributes.TakeDamage(healthDecreaseRate * Time.fixedDeltaTime);
            }
        }

        // 检测W键按下并施加额外向上的加速度
        if (isPressingW)
        {
            rb.AddForce(Vector2.up * extraUpwardAcceleration);
            if (playerAttributes != null)
            {
                playerAttributes.TakeDamage(healthDecreaseRate * Time.fixedDeltaTime);
            }
        }

        // 限制垂直速度
        if (rb.velocity.y > maxVerticalSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxVerticalSpeed);
        }
        else if (rb.velocity.y < -maxVerticalSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, -maxVerticalSpeed);
        }

        // 限制水平速度
        if (rb.velocity.x > maxHorizontalSpeed)
        {
            rb.velocity = new Vector2(maxHorizontalSpeed, rb.velocity.y);
        }
        else if (rb.velocity.x < -maxHorizontalSpeed)
        {
            rb.velocity = new Vector2(-maxHorizontalSpeed, rb.velocity.y);
        }
    }
}



