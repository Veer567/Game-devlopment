using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerMovments : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    [SerializeField] private LayerMask JumpableGround ;
    private float dirX = 0f;    
    private Animator anim;
    private SpriteRenderer sprite; 
    [SerializeField]private float movementspeed = 8f;
    [SerializeField]private float jumpforce =14f;
    private enum MovementState {idle, running, jump, fall}
    [SerializeField] private AudioSource Jumpeffect;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
             dirX = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(dirX * movementspeed, rb.velocity.y );
            if(Input.GetButtonDown("Jump") && IsGrounded())
            {
                Jumpeffect.Play();
                rb.velocity = new Vector2(rb.velocity.x,jumpforce);
            }
            AnimationUpdate();
    }
    private void AnimationUpdate()
    {
        MovementState state;
        if (dirX > 0f) 
        {
            state = MovementState.running;
            sprite.flipX= false;
        }
       else if (dirX < 0f) 
        {
            state = MovementState.running;
            sprite.flipX= true;
        }
        else
        {
            state = MovementState.idle;
        }
        if(rb.velocity.y > .1f)
        {
            state = MovementState.jump;
        }
        else if(rb.velocity.y < -.1f)
        {
            state = MovementState.fall;
        }
        anim.SetInteger("state",(int)state);
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, JumpableGround);
    }

}
