using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootAI : MonoBehaviour
{
    public Transform target;
    public Transform gun;
    public Transform GFX;

    public float fireRate = 2f;

    public Rigidbody2D rb;
    public Transform ShootPoint;
    public GameObject Bullet;

    public EnemyPatrolAI enemyPatrolAI;

    private Animator animator;

    [HideInInspector]
    public bool isfacingRight = true;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        StartCoroutine(shootPlayer(fireRate));
    }


    void Update()
    {
        if (!Physics2D.Linecast (gun.position, target.position))
        {
            if (Vector2.Distance(gun.position, target.position) < 10)
            {
                Vector3 dir = gun.position - target.position; 
                float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg; 
                gun.rotation = Quaternion.AngleAxis(angle -90, Vector3.forward);
                enemyPatrolAI.mustPatrol = false;
                rb.velocity = new Vector2(0, 0);
                animator.SetBool("IsPatrolling", false);
                if (!isfacingRight && dir.x > -1f)
                {
                    Flip();
                }
                else if (isfacingRight && dir.x < -1f)
                {
                    Flip();
                }
            }
            else
            {
                continuePatrol();
            }
        }
        else
        {
            continuePatrol();
        }

    }

void continuePatrol()
{ 
    animator.SetBool("IsPatrolling", true);
    if (enemyPatrolAI.isfacingLeft && transform.localScale.x == -1)
    {
    Flip();
    }
    else if (!enemyPatrolAI.isfacingLeft && transform.localScale.x == 1)
    {
    Flip();
    }
    enemyPatrolAI.mustPatrol = true;
}

private IEnumerator shootPlayer(float fireRate)
{
    while (true)
    {
        yield return new WaitForSeconds(fireRate);
        if (!Physics2D.Linecast (gun.position, target.position))
        {
            if (Vector2.Distance(gun.position, target.position) < 10)
            {
                Vector2 myPos = new Vector2(ShootPoint.position.x, ShootPoint.position.y); //our curr position is where our muzzle points
                GameObject projectile = Instantiate(Bullet, myPos, ShootPoint.rotation); //create our bullet
                Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(), GFX.GetComponent<Collider2D>());
                Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(), target.GetComponent<Collider2D>());
                Vector2 direction = myPos - (Vector2)target.position; //get the direction to the target
                projectile.GetComponent<Rigidbody2D>().velocity = direction * -1f * 10f; //shoot the bullet
            }
        }
    }
}

    private void Flip()
    {
        isfacingRight = !isfacingRight;
        Vector3 localScale = GFX.localScale;
        localScale.x *= -1f;
        GFX.localScale = localScale;
    }

}
