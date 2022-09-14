using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    //Store Ref for RigidBody
    private Rigidbody2D rBody;
    private Animator anim;
    private CapsuleCollider2D capsColl2D;

    //Stores movement Speed
    [SerializeField] private float moveSpeed;
    private float moveX = 0f;

    //jump variables
    public LayerMask groundLayer;
    [SerializeField] private float jumpForce = 0f;
    [SerializeField] private float jumpFalloff = 0.5f;
    [SerializeField] private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;
    [SerializeField] private float jumpBuffer = 0.2f;
    private float jumpBufferCounter;
    private float jumpCooldown = 0.4f;
    private bool isJumping;

    //Variables for checking playerstate
    private bool isGrounded;

    //VFX
    //public ParticleSystem feetDust;

    // Start is called before the first frame update
    void Start()
    {
        //STORE CORE REFS
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        capsColl2D = GetComponent<CapsuleCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //PLAYER INPUT
        moveX = Input.GetAxis("Horizontal");

        //Checks if player is touching ground
        IsGrounded();

        //Flips character to face the way they move.
        DirectionCheck();

        //Coyote Time Logic
        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        //JumpBuffer Logic
        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBuffer;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        // PLAYER JUMP
        if (jumpBufferCounter >= 0 && coyoteTimeCounter > 0 && !isJumping)
        {
            Jump();
            StartCoroutine(JumpCooldown());
        }

        // Allows player to do smaller jump
        if (Input.GetButtonUp("Jump") && rBody.velocity.y > 0)
        {
            rBody.velocity = new Vector2(rBody.velocity.x, rBody.velocity.y * jumpFalloff);
        }

        //SET UP ANIMATIONS
        anim.SetBool("isRunning", moveX != 0);
        anim.SetBool("isGrounded", IsGrounded());

        if (rBody.velocity.y <= -0.5f)
        {
            anim.SetBool("isFalling", true);
        }
        else { anim.SetBool("isFalling", false); }

        //FeetDust
        //if (moveX != 0 && IsGrounded())
        //{
        //    CreateFeetDust();
        //}
        //else { feetDust.Stop(); }

    }

    private void FixedUpdate()
    {
        rBody.velocity = new Vector2(moveX * moveSpeed, rBody.velocity.y);
    }

    //------------------------------- PLAYER FUNCTIONS -----------------------

    private void Jump()
    {
        rBody.velocity = new Vector2(rBody.velocity.x, jumpForce);
        isGrounded = false;
        jumpBufferCounter = 0;
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(capsColl2D.bounds.center, capsColl2D.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
        
    }

    private void DirectionCheck()
    {
        if (moveX >= 0.1)
        {
            transform.localScale = Vector2.one;
        }
        else if (moveX <= -0.1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private IEnumerator JumpCooldown()
    {
        isJumping = true;
        yield return new WaitForSeconds(jumpCooldown);
        isJumping = false;
    }

    //void CreateFeetDust()
    //{
    //    feetDust.Play();
    //}
}
