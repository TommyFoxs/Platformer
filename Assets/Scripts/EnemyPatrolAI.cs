using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolAI : MonoBehaviour
{
    [HideInInspector]
    public bool mustPatrol;
    private bool mustTurn;
    private int defaultGunRotation = -90;
    public Transform gun;

    public float walkSpeed;
    public LayerMask groundLayer;
    public bool isfacingLeft;

    public Rigidbody2D rb;
    public Transform groundCheckPos;
    public EnemyShootAI enemyShootAI;
    public Collider2D bodyCollider;


    void Start()
    {
        isfacingLeft = true;
        mustPatrol = true;
        gun = enemyShootAI.gun;
    }

    // Update is called once per frame
    void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        }
    }

    void Patrol()
    {
        if (mustPatrol)
        {
            mustTurn = Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
        if (mustTurn || bodyCollider.IsTouchingLayers(groundLayer))
        {
            Flip();
        }
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
        gun.eulerAngles = new Vector3(0, 0, defaultGunRotation);

    }

    void Flip()
    {
        defaultGunRotation = -defaultGunRotation;
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        isfacingLeft = !isfacingLeft;
        enemyShootAI.isfacingRight = !enemyShootAI.isfacingRight;
        mustPatrol = true;
    }

}
