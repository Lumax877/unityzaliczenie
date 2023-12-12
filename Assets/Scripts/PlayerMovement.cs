using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D player;
    private Animator animation;
    private SpriteRenderer sprite;
    private BoxCollider2D collider;
    [SerializeField] private LayerMask jumpableGround;
    private float X = 0f;
    private float moveSpeed = 7f;
    private float jumpForce = 12f;
    private enum MoveState {idle, run, jump, fall, doublejump}
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource pierd;
    private bool candouble;
    public ItemCollection item;
    
    // Start is called before the first frame update
    void Start()
    {
        player =  GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        X = Input.GetAxisRaw("Horizontal");
        player.velocity = new Vector2(X * moveSpeed, player.velocity.y);


        if (Input.GetKeyDown("space") && IsGrounded())
        {
            player.velocity = new Vector2(player.velocity.x, jumpForce);
            jumpSound.Play();
        }

        if (Input.GetKeyDown("space") && !IsGrounded() && candouble && item.GetStrawberriesCount() > 0)
        {
            player.velocity = new Vector2(player.velocity.x, jumpForce);
            candouble = false;
            pierd.Play();
            item.DecreaseStrawberriesCount(1);
        }

        if (!candouble && IsGrounded())
        {
            candouble = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            player.velocity = new Vector2(player.velocity.x + jumpForce, player.velocity.y);
        }

        AnimationController();
    }

    void AnimationController()
    {
        MoveState state;

        if (X > 0f)
        {
            state = MoveState.run;
            sprite.flipX = false;
        }
        else if (X < 0f)
        {
            state = MoveState.run;
            sprite.flipX = true;
        }
        else
        {
            state = MoveState.idle;
        }

        if (player.velocity.y > .1f)
        {
            if (!candouble)
            {
                state = MoveState.doublejump;
            }
            else
            {
                state = MoveState.jump;
            }
        }
        else if (player.velocity.y < -.1f)
        {
            if (!candouble)
            {
                state = MoveState.doublejump;
            }
            else
            {
                state = MoveState.jump;
            }
        }
        

        animation.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
