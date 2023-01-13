using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsingPlatform : MonoBehaviour
{
    public Collider2D collider;
    public Animator animator;
    private bool hasCollided = false;

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            if (hasCollided == false)
            {
                if (col.gameObject.transform.position.y-1 > transform.position.y)
                {
                    hasCollided = true;
                    StartCoroutine(CollapseBlock());
                }
            }
        }
    }

    IEnumerator CollapseBlock()
    {
        yield return new WaitForSeconds(1f);
        collider.enabled = !collider.enabled;
        animator.SetTrigger("PlatformClose");
        yield return new WaitForSeconds(5f);
        collider.enabled = !collider.enabled;
        animator.SetTrigger("PlatformOpen");
        hasCollided = false;
    }
}
