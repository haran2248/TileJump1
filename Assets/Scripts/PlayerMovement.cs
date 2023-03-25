using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
   private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    private float dirX = 0f;

    private enum MovementState { idle,running,jumping,falling};
    [SerializeField]private LayerMask jumpableGround;
    //private MovementState state = MovementState.idle;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
         dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);
        if(Input.GetKeyDown(KeyCode.UpArrow)&&isGrounded())
        {
            Debug.Log("up");
            rb.velocity = new Vector2(rb.velocity.x, 7f);
        }
        UpdateAnimationState();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Questt"))
        {
            Debug.Log("Collided with Questt");
            rb.velocity = new Vector2(rb.velocity.x, 15f);
        }
    }
    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.running;
            //anim.SetBool("Running", true);
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            //anim.SetBool("Running", true);
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
            //anim.SetBool("Running", false);
        }
        if(rb.velocity.y>0.1f)
        {
            state = MovementState.jumping;
        }
        else if(rb.velocity.y<-0.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }
    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }


}
