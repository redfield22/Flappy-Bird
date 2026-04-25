using UnityEngine;

public class TeleportProjectile : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
    public Transform player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.right * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pipe"))
        {
            player.position = new Vector3(
                transform.position.x + 0.5f,
                player.position.y,
                player.position.z
            );

            Destroy(gameObject);
        }
    }
}