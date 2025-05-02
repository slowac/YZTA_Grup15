using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerClone : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    [Header("Crouch Settings")]
    public Vector3 standScale = new Vector3(1, 1, 1);
    public Vector3 crouchScale = new Vector3(1, 0.5f, 1);

    [Header("Universe Settings")]
    public Universe myUniverse;

    private Rigidbody rb;
    private bool isGrounded;
    private bool isCrouching;

    private bool isFrozen;

    private float _moveInput;
    private bool _jumpInput;
    private bool _crouchInput;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.localScale = standScale;

        if (myUniverse == null)
        {
            myUniverse = GetComponentInParent<Universe>();
        }
    }

    void Update()
    {
        if (isFrozen || GetComponent<RewindRecorder>().IsRewinding())
        {
            return;
        }

        HandleMovement();
        HandleJump();
        HandleCrouch();
        //LockZAxis();
    }

    public int GetUniverseID()
    {
        return myUniverse != null ? myUniverse.universeID : -1;
    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector3 velocity = new Vector3(horizontal * moveSpeed, rb.linearVelocity.y, 0f);
        rb.linearVelocity = velocity;
    }

    void HandleJump()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isCrouching)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, 0f);
        }
    }

    void HandleCrouch()
    {
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            if (!isCrouching)
            {
                transform.localScale = crouchScale;
                isCrouching = true;
            }
        }
        else if (isCrouching)
        {
            transform.localScale = standScale;
            isCrouching = false;
        }
    }

    public void ReceiveInput(float move, bool jump, bool crouch)
    {
        _moveInput = move;
        _jumpInput = jump;
        _crouchInput = crouch;
    }

    public void SetFrozen(bool frozen)
    {
        isFrozen = frozen;

        if (frozen)
        {
            rb.linearVelocity = Vector3.zero;
            rb.isKinematic = true; 
        }
        else
        {
            rb.isKinematic = false;
        }
    }

    /*void LockZAxis()
    {
        Vector3 pos = transform.position;
        pos.z = 0f;
        transform.position = pos;
    }*/
}
