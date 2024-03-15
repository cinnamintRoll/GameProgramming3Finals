using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    public float moveSpeed;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

        // Flip the sprite based on the movement direction
        if (direction.x < 0)
        {
            spriteRenderer.flipX = true; // Facing left
        }
        else
        {
            spriteRenderer.flipX = false; // Facing right or idle (no movement)
        }
    }
}