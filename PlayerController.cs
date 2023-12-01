using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D theRB;
    private Animator anim;
    public float moveSpeed, jumpForce;
    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;
    
    public bool springed = false;
    // Start is called before the first frame update
    void Start()
    {   
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (springed)
        {
            return;
        }
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, 0.2f, whatIsGround);
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, theRB.velocity.y);
        IsJumpKeyPressed();
        UpdateAnimations();
        FaceMoveDirection();
    }

    void Spring()
    {
        theRB.velocity = Vector2.zero;
        theRB.AddForce(transform.up * 50, ForceMode2D.Impulse);
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "FinalSpring")
        {
            springed = false;
        }
    }

    void IsJumpKeyPressed()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        } 
        else if (Input.GetButtonUp("Jump") && !isGrounded && theRB.velocity.y > 0)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, theRB.velocity.y * 0.5f);
        }
    }
    
    void UpdateAnimations()
    {
        anim.SetFloat("speed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
    }

    void FaceMoveDirection()
    {
        float xscale = transform.localScale.x;
        if (theRB.velocity.x < 0)
        {
            
            transform.localScale = new Vector3(-1f * Mathf.Abs(xscale), 1f * Mathf.Abs(xscale), 1f);
        }
        else if (theRB.velocity.x > 0)
        {
            transform.localScale = new Vector3(1f * Mathf.Abs(xscale), 1f * Mathf.Abs(xscale), 1f);
        }
    }
}
