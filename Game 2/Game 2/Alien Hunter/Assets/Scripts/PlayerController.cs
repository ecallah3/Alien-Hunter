using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;

    [SerializeField]GameObject attackHitbox;
    [SerializeField]GameObject attackHitboxAir;
    [SerializeField]GameObject playerHurtbox;
    bool isAttacking = false;
    bool nextAttack = false;

    [SerializeField]Transform groundCheck;
    [SerializeField]Transform groundCheckL;
    [SerializeField]Transform groundCheckR;
    bool isGrounded;

    [SerializeField]private float runSpeed = 25;
    [SerializeField]private float jumpSpeed = 50;
    [SerializeField]public float jumpTime;
    //[SerializeField]public int extraJumps;
    private float jumpTimeCounter;
    [SerializeField]private bool canJump;
    

    [Header("Dashing")]
    public bool canDash = true;
    public float dashingTime;
    public float dashSpeed;
    public float dashJumpIncrease;

    // Call the components -----------------------------------------------------------------------------------------
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        attackHitbox.SetActive(false);
    }

    //Attacking ----------------------------------------------------------------------------------------------------
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isAttacking)
        {
            isAttacking = true;
            float delay = .4f;
            //float window = 1.0f;
            if (isGrounded)
            {
                // Set up the 1-2-3 Combo
                animator.Play("Player_attack1");
                StartCoroutine(DoAttack(delay));
                //Invoke("NextAttack", window);
                //if (Input.GetButtonDown("Fire1") && nextAttack)
                //{
                //    //animator.Stop();
                //    animator.Play("Player_attack2");
                //    StartCoroutine(DoAttack(delay));
                //    Invoke("NextAttack", window);
                //    if (Input.GetButtonDown("Fire1") && nextAttack)
                //    {
                //        //animator.Stop();
                //        animator.Play("Player_attack3");
                //        StartCoroutine(DoAttack(delay));
                //        Invoke("ResetAttack", delay);
                //    }
                //}
            }
            else if (!isGrounded)
            {
                animator.Play("Player_airattack");
                StartCoroutine(DoAirAttack(delay));
            }
            else
            {
                Invoke("ResetAttack", delay);
            }
        }
        if (isGrounded)
        {
            attackHitboxAir.SetActive(false);
        }
    }
    //Activate the hitboxes
    IEnumerator DoAttack(float delay)
    {
        attackHitbox.SetActive(true);;
        yield return new WaitForSeconds(delay);
        attackHitbox.SetActive(false);
        isAttacking = false;
    }
    IEnumerator DoAirAttack(float delay)
    {
        attackHitboxAir.SetActive(true);
        yield return new WaitForSeconds(delay);
        attackHitboxAir.SetActive(false);
        isAttacking = false;
    }
    //void NextAttack()
    //{
    //    //Window to start the next attack
    //    nextAttack = true;
    //}
    void ResetAttack()
    {
        //Stop attacking
        isAttacking = false;
        nextAttack = false;
    }

    // Player Controller ------------------------------------------------------------------------------------------------
    private void FixedUpdate()

    {   // If line cast goes from player to ground and hits ground layer, return true
        if ((Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"))) ||
          (Physics2D.Linecast(transform.position, groundCheckL.position, 1 << LayerMask.NameToLayer("Ground"))) ||
          (Physics2D.Linecast(transform.position, groundCheckR.position, 1 << LayerMask.NameToLayer("Ground"))))
        {
            isGrounded = true;
            canJump = true;
        }
        else
        {
            isGrounded = false;
            if(!isAttacking)
            {
                animator.Play("Player_fall");
            }
        }

        // Movement and jump inputs-----------------------------------------------------------------------------------
        // move right
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            if (!isAttacking)
            {
                rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);
            }
            else if (isAttacking && isGrounded)
            {
                rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            }
            else if (isAttacking && !isGrounded)
            {
                rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);
            }
            if (isGrounded && canDash && !isAttacking)
                animator.Play("Player_run");
            
            transform.localScale = new Vector3(1, 1, 1);
        }
        // move left
        else if(Input.GetKey("a") || Input.GetKey("left"))
        {
            if (!isAttacking)
            {
                rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);
            }
            else if (isAttacking && isGrounded)
            {
                rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            }
            else if (isAttacking && !isGrounded)
            {
                rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);
            }
            if (isGrounded && canDash && !isAttacking)
                animator.Play("Player_run");

            transform.localScale = new Vector3(-1, 1, 1);
        }
        // idle
        else if (isGrounded && canDash)
        {
            if (!isAttacking)
            {
                animator.Play("Player_idle");
            }
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
        // Jumping - jump heights and double jump ---------------------------------------------------------------
        if (Input.GetKeyDown("space") && isGrounded && canJump)
        {
            canJump = true;
            jumpTimeCounter = jumpTime;
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
            animator.Play("Player_jump");
        }
        if (canJump)
        {
            if (Input.GetKeyDown("space") && !isGrounded && canJump)
            {
                canJump = false;
                jumpTimeCounter = jumpTime;
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
                animator.Play("Player_jump");
                if (isGrounded)
                {
                    canJump = true;
                }
            }
        }
        if (Input.GetKey("space") && canJump)
        {
            if (jumpTimeCounter > 0)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
                jumpTimeCounter -= Time.deltaTime;
            }
        }
        // Dashing ---------------------------------------------------------------------------------------------
        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
        {
            DashAbility();
            animator.Play("Player_dash");
        }       
    }
    void DashAbility()
    {
        if (canDash)
        {
            StartCoroutine(Dash());
        }
    }
    IEnumerator Dash()
    {
        canDash = false;
        runSpeed = dashSpeed;
        jumpSpeed = dashJumpIncrease;
        yield return new WaitForSeconds(dashingTime);
        canDash = true;
        runSpeed = 25;
        jumpSpeed = 50;
        
    }   
}