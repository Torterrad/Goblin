using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody2D rb;

    [Header("Components")]
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] SpriteRenderer playerSprite;

    [Header("Movement Variables")]
    [SerializeField] private float Acceleration = 50f;
    [SerializeField] private float maxSpeed = 14f;
    [SerializeField] private float groundlinearDrag = 5f;
    private float horizontalDirection;

    [Header("Jump Varibles")]
    [SerializeField] private float jumpForce = 12f; //jump force
    [SerializeField] private float airLinearDrag = 2.5f; //drag while airborne
    [SerializeField] private float fallMultiplier = 8f; //gravity scale changer
    public bool isFalling;
    public float lastYPos = 0;

    [Header("Ground Collision Variables")]
    public bool onGround;
    public bool onPlayer;
    [SerializeField] Transform groundCheck;
    [SerializeField] float checkDistance;



    public Animator squashStrechAnimator;

    //if velocity is moving the direction opposite to the inputed direction the player is changing direction
    private bool changingDirection => rb.velocity.x > 0f && horizontalDirection < 0f || (rb.velocity.x < 0f && horizontalDirection > 0f);

    //can jump bool true if pressing the jump button and on the ground
    private bool canJump => Input.GetButtonDown("Jump") && (onGround || onPlayer);

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastYPos = 0; //initialise last position to 0

        //DISTINGUIST BETWEEN PLAYER 1 AND 2 FOR BETTER MOVEMENT SCRIPT EFFECIENCY
        Physics2D.IgnoreLayerCollision(7, 8, true);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalDirection = GetInput().x; //get current input of player
        if (canJump)
            Jump();
       
    }

    private void FixedUpdate()
    {
        CheckCollisions(); //check what the player is colliding with 
        lastYPos = transform.position.y; //check if the player Y is lower than it was last update
        MoveCharacter(); //move player function

        if (onGround) // if on the ground
        {
            ApplyGroundLinearDrag(); //apply ground drag
        }
        else //while airborne
        {
            ApplyAirLinearDrag(); //apply air drag
            FallMultiplier();
        }

        if (horizontalDirection > 0)
        {
            playerSprite.flipX = false;
        }
        else if (horizontalDirection < 0)
        {
            playerSprite.flipX = true;
        }
    }

    private Vector2 GetInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); //get input horizontal which unity assigns to A/D and left/right arrow keys
    }

    private void MoveCharacter()
    {
        //move player's horizontal direction by accelteration
        rb.AddForce(new Vector2(horizontalDirection, 0f) * Acceleration);

        if (Mathf.Abs(rb.velocity.x) > maxSpeed) //player can accelerate to maxspeed but not over it
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
    }

    private void ApplyGroundLinearDrag()
    {
        if (Mathf.Abs(horizontalDirection) < 0.4f || changingDirection) //if moving apply drag
        {
            rb.drag = groundlinearDrag;
        }
        else //dont apply drag or player will drift
        {
            rb.drag = 0f;
        }
    }

    private void ApplyAirLinearDrag()
    {
        rb.drag = airLinearDrag;  //set drag to air linear drag
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f); //halt vertial movement
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); //apply jumpforce upward
        FindObjectOfType<AudioManager>().Play("Jump");
        squashStrechAnimator.SetTrigger("Jump");
    }

    private void FallMultiplier()
    {
        if (rb.velocity.y < 0) //if falling change gravity scale to fall multiplier
        {
            rb.gravityScale = fallMultiplier;
        }
        else
        {
            rb.gravityScale = 3f;
        }
    }

    private void CheckCollisions()
    {
        //check collision with ground layer using raycast
        onGround = Physics2D.Raycast(groundCheck.position, -transform.up, checkDistance, groundLayer);
        onPlayer = Physics2D.Raycast(groundCheck.position, -transform.up, checkDistance, playerLayer);

        //if not on the ground and y posiiton is less than what it last was then the player is falling
        if ((!onGround || !onPlayer) && transform.position.y < lastYPos)
            isFalling = true;

        if ((onGround || onPlayer) && isFalling) //if player has just landed
        {
            isFalling = false; //player is no longer falling
        }
    }
    private void OnDrawGizmos()
    {
        //draw gizmos helps during testing, this shows the distance of raycast shooting
        Gizmos.color = Color.green;
        Gizmos.DrawLine(groundCheck.position, new Vector2(groundCheck.position.x, groundCheck.position.y - checkDistance));
    }
}