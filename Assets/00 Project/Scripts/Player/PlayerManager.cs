using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3;

    Vector2 moveInput;
    Vector3 Input3D;

    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        MoveRigidbody();
    }

    void MoveRigidbody()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        Input3D = new Vector3(moveInput.x, 0, moveInput.y);
        FlipSprite();
        UpdateMoveAniamtion();
    }
    void FlipSprite()
    {
        if(moveInput.x > 0)
            spriteRenderer.flipX = true;
        else if(moveInput.x < 0)
            spriteRenderer.flipX = false;
    }

    void UpdateMoveAniamtion()
    {
        float moveAmount = moveInput.sqrMagnitude;
        animator.SetFloat("MoveInput", moveAmount);
    }



}
