using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 30;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Collided " +  collision.name);

        if (collision.CompareTag("Player"))
            return;

        Destroy(gameObject);
    }

}
