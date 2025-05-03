using System.Collections;
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

    private Vector3 gravityDirection = Vector3.down;

    private Quaternion targetRotation;
    private float rotationSpeed = 5f;

    private bool justTeleported = false;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.localScale = standScale;

        if (myUniverse == null)
        {
            myUniverse = GetComponentInParent<Universe>();
        }

        rb.useGravity = false;

        targetRotation = transform.rotation;
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

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    void FixedUpdate()
    {
        if (!isFrozen && !GetComponent<RewindRecorder>().IsRewinding())
        {
            rb.AddForce(gravityDirection * 20f); // Özel yerçekimini uygula
        }
    }

    public int GetUniverseID()
    {
        return myUniverse != null ? myUniverse.universeID : -1;
    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        // reverse check
        var reverse = myUniverse.GetComponent<UniverseReverse>();
        if (reverse != null && reverse.IsReversed)
        {
            horizontal *= -1;
        }

        Vector3 velocity = new Vector3(horizontal * moveSpeed, rb.linearVelocity.y, 0f);
        rb.linearVelocity = velocity;
    }

    void HandleJump()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isCrouching)
        {
            //rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, 0f); //sabit yone ziplama
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, -jumpForce * gravityDirection.y, 0f);

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

    public void SetGravityDirection(Vector3 dir)
    {
        gravityDirection = dir.normalized;

        if (dir == Vector3.down)
            targetRotation = Quaternion.Euler(0, 0, 0);
        else if (dir == Vector3.up)
            targetRotation = Quaternion.Euler(0, 0, 180);
    }


    public void TeleportTo(Vector3 position)
    {
        rb.linearVelocity = Vector3.zero;
        transform.position = position;

        if (!isFrozen)
            StartCoroutine(TeleportCooldown());
    }

    private IEnumerator TeleportCooldown()
    {
        justTeleported = true;
        yield return new WaitForSeconds(0.5f);
        justTeleported = false;
    }

    public bool IsInTeleportCooldown()
    {
        return justTeleported;
    }

    /*void LockZAxis()
    {
        Vector3 pos = transform.position;
        pos.z = 0f;
        transform.position = pos;
    }*/
}
