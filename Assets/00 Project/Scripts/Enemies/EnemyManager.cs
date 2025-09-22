using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] Transform player;

    Vector2 targetDirection;
    float moveSpeed = 5;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        CalcDir();
        MoveRigidbody();
    }

    void CalcDir()
    {
        targetDirection = player.position - transform.position;
        targetDirection.Normalize();
    }

    void MoveRigidbody()
    {
        rb.linearVelocity = targetDirection * moveSpeed;
    }
}
