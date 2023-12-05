using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCsJumpsandWalk : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Transform currentPoint;
    public float speed;
    public float jumpInterval = 5f; //this is the time between jumps
    private float jumpTimer = 0f;
    public float jumpForce = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
    }

    void Update()
    {
        MoveNPC();

        // Update jump timer
        jumpTimer += Time.deltaTime;

        // Check time to jump
        if (jumpTimer >= jumpInterval)
        {
            Jump();
            jumpTimer = 0f; // Reset timer
        }
    }

    void MoveNPC()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == pointB.transform)
        {
            Flip();
            currentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == pointA.transform)
        {
            Flip();
            currentPoint = pointB.transform;
        }
    }

      void Jump()
    {
        // Add a force to make the NPC jump, with a random factor
        float randomJumpFactor = Random.Range(1.0f, 1.5f); // Adjust the range as needed
        rb.AddForce(new Vector2(0f, jumpForce * randomJumpFactor), ForceMode2D.Impulse);
    }

    void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 1f);
        Gizmos.DrawWireSphere(pointB.transform.position, 1f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}
