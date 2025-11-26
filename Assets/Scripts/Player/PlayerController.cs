using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement - Adjust in Speed Controller")]


    [Header("Jump")]
    [SerializeField] private float jumpForce = 7f;

    private Rigidbody rb;
    private PlayerInputActions input;
    private bool isGrounded = false;
    private bool justJumped = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        input = new PlayerInputActions();
        input.Player.Jump.performed += TryJump;
    }

    void OnEnable() => input.Enable();
    void OnDisable() => input.Disable();

    void FixedUpdate()
    {
        if (GameManager.Instance != null && GameManager.Instance.IsGameOver)
            return;

        MoveForward();
        justJumped = false;
    }

    void Update()
    {
        RecordState();
    }

    void MoveForward()
    {
        Vector3 forwardVel = transform.forward * SpeedController.Instance.currentSpeed;
        rb.linearVelocity = new Vector3(forwardVel.x, rb.linearVelocity.y, forwardVel.z);
    }

    void TryJump(InputAction.CallbackContext ctx)
    {
        if (!isGrounded) return;
        if (GameManager.Instance != null && GameManager.Instance.IsGameOver) return;

        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
        justJumped = true;
    }

    void RecordState()
    {
        if (SyncManager.Instance == null) return;

        PlayerState state = new PlayerState(
            Time.time,
            transform.localPosition,
            rb.linearVelocity,
            transform.localRotation,
            justJumped,
            isGrounded
        );

        SyncManager.Instance.RecordState(state);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }
}
