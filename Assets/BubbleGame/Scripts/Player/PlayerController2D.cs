using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public float upwardAcceleration = 1f; 
    public float extraUpwardAcceleration = 5f; 
    public float horizontalForce = 10f; 
    public float downwardForce = 10f; 
    public float maxVerticalSpeed = 30f; 
    public float maxHorizontalSpeed = 10f; 
    public float healthDecreaseRate = 1f; 
    public Rigidbody2D rb;
    private bool isPressingS = false;
    private bool isPressingW = false;
    private float sPressTime = 0f;
    private PlayerAttributes playerAttributes;

    private float lastFreezeTime = 0f;
    public bool isFreezed = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAttributes = GetComponent<PlayerAttributes>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * horizontalForce);
            UnfreezePlayer();
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * horizontalForce);
            UnfreezePlayer();
        }


        if (Input.GetKeyDown(KeyCode.S))
        {
            isPressingS = true;
            UnfreezePlayer();

        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            isPressingS = false;
            sPressTime = 0f; 
        }

        
        if (Input.GetKeyDown(KeyCode.W))
        {
            isPressingW = true;
            UnfreezePlayer();

        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            isPressingW = false;
        }
    }

    // FixedUpdate is called once per physics update
    void FixedUpdate()
    {
        
        rb.AddForce(Vector2.up * upwardAcceleration);

        
        if (isPressingS)
        {
            rb.AddForce(Vector2.down * downwardForce);
            sPressTime += Time.fixedDeltaTime;
            if (playerAttributes != null)
            {
                playerAttributes.TakeDamage(healthDecreaseRate * Time.fixedDeltaTime);
            }
        }

        
        if (isPressingW)
        {
            rb.AddForce(Vector2.up * extraUpwardAcceleration);
            if (playerAttributes != null)
            {
                playerAttributes.TakeDamage(healthDecreaseRate * Time.fixedDeltaTime);
            }
        }

        
        if (rb.velocity.y > maxVerticalSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxVerticalSpeed);
        }
        else if (rb.velocity.y < -maxVerticalSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, -maxVerticalSpeed);
        }

        
        if (rb.velocity.x > maxHorizontalSpeed)
        {
            rb.velocity = new Vector2(maxHorizontalSpeed, rb.velocity.y);
        }
        else if (rb.velocity.x < -maxHorizontalSpeed)
        {
            rb.velocity = new Vector2(-maxHorizontalSpeed, rb.velocity.y);
        }
    }
    
    public void FreezePlayer()
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.isKinematic = true;
        isFreezed = true;
        lastFreezeTime = Time.time;
    }
    public void UnfreezePlayer()
    {
        if (Time.time - lastFreezeTime < 0.5f) return;
        isFreezed = false;
        rb.isKinematic = false;
    }
    
}



