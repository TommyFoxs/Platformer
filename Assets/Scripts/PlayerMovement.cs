using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    [SerializeField]
    private Transform[] groundCheck;
    [SerializeField]
    private LayerMask groundLayer;
    public PlayerManager playermanager;

    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip jumpSound;

    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 12f;
    private bool isfacingRight = true;

    private int sceneIndex;

    [SerializeField] private GameObject speech;

    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        if (sceneIndex == 7)
        {
            var loc = this.transform.position;
            loc.y += 2;
            speech.transform.position = loc;
        }
        if (playermanager.isDead == true)
        {
            rb.velocity = new Vector2(0, 0);
            return;
        }
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        animator.SetFloat("Y_Velocity", rb.velocity.y);
        animator.SetBool("IsGrounded", isGrounded());
        if (!isfacingRight && horizontal < 0f)
        {
            Flip();
        }
        else if (isfacingRight && horizontal > 0f)
        {
            Flip();
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            source.PlayOneShot(jumpSound, MainManager.Volume);
        }

         if (context.canceled && rb.velocity.y > 0f)
         {
             rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
         }
    }

    private bool isGrounded()
    {//foreach couldve worked too, tho no i var then 
        for (int i = 0; i < groundCheck.Length; i++)//1st statement is before loop, then condition and after is code that runs after each loop
        {
            if (Physics2D.OverlapCircle(groundCheck[i].position, 0.2f, groundLayer))
            {
                return true;
            }
        }
        return false;
        //return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer | groundLayer2);
    }

    private void Flip()
    {
        isfacingRight = !isfacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
        if (sceneIndex == 7)
        {
            speech.transform.localScale = localScale;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }
}
