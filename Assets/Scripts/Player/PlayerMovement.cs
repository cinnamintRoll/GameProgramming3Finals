using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Movement
    public float moveSpeed;
    [HideInInspector]
    public Vector2 moveDir;
    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;
    [HideInInspector]
    public Vector2 lastMovedVector;
    private float originalMoveSpeed;
    private bool isDodging = false;
    public float dodgeSpeed = 10f;

    //References
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastMovedVector = new Vector2(1, 0f); //If we don't do this and game starts up and don't move, the projectile weapon will have no momentum
        originalMoveSpeed = moveSpeed;
    }

    void Update()
    {
        InputManagement();
    }

    void FixedUpdate()
    {
        Move();
    }

    void InputManagement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            // Start the dodge
            isDodging = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            // End the dodge when the "Q" key is released
            isDodging = false;
        }

        if (moveDir.x != 0)
        {
            lastHorizontalVector = moveDir.x;
            lastMovedVector = new Vector2(lastHorizontalVector, 0f);    //Last moved X
        }

        if (moveDir.y != 0)
        {
            lastVerticalVector = moveDir.y;
            lastMovedVector = new Vector2(0f, lastVerticalVector);  //Last moved Y
        }

        if (moveDir.x != 0 && moveDir.y != 0)
        {
            lastMovedVector = new Vector2(lastHorizontalVector, lastVerticalVector);    //While moving
        }
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);

        if (isDodging)
        {
            rb.velocity = lastMovedVector.normalized * dodgeSpeed;
            // You can also add other effects during the dodge (e.g., invincibility frames)
        }
        else
        {
            // Regular movement
            rb.velocity = moveDir * moveSpeed;
        }
    }

    public void ApplySlowDebuff(float slowFactor)
    {
        moveSpeed *= slowFactor;
    }

    public void ResetSpeed()
    {
        moveSpeed = originalMoveSpeed;
    }
}