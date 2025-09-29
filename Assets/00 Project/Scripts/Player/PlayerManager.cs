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
    Camera cam;
    AudioSource audioSource;

    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletSpawnTransform;
    [SerializeField] Transform weaponRoot;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        cam = Camera.main;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Mouse Pos
        Vector2 mousePixelPos = Mouse.current.position.ReadValue();

        // Conv Pixel to Game Pos
        Vector2 mouseWorldPos = cam.ScreenToWorldPoint(mousePixelPos);

        // Calc Dir To Mouse
        Vector2 direction = mouseWorldPos - (Vector2)transform.position;

        // Rot Root Along Dir
        weaponRoot.right = direction;
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

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        audioSource.pitch = 1 + Random.Range(-0.2f, 0.2f);
        audioSource.Play();

        Instantiate(bullet, bulletSpawnTransform.position, bulletSpawnTransform.rotation);
    }
}
