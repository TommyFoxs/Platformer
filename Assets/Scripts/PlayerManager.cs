using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public bool hasKeycard = false;
    public GameObject blackOutSquare;

    public LevelChanger levelchanger;
    public bool isDead = false;
    public Animator animator;
    [SerializeField]
    private LayerMask TriggerLayer;

    [SerializeField]
    private Transform player;
    Camera camera;


    [SerializeField] private PlayerInput playerinput;

    void Start()
    {
        camera = Camera.main;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.layer == 6)//touch death object
        {
            Death();
        }
        else if(col.gameObject.layer == 10)
        {
            if (hasKeycard == true)
            {
                Destroy(col.gameObject);
                hasKeycard = false;
            }
        }
    }



    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 11)
        {
            if (hasKeycard == false)
            {
                Destroy(col.gameObject);
                hasKeycard = true;
            }
        }
        else if (col.gameObject.layer == 13)
        {
            StartCoroutine(deathPit(0.5f));
        }
        else if (col.gameObject.layer == 14)
        {
            StartCoroutine(exitLevel(col.gameObject));
        }
    }

    private IEnumerator exitLevel(GameObject elevatorObject)
    {
        ElevatorScript elevator = elevatorObject.GetComponent<ElevatorScript>();
        if (elevator.isExit == true)
        {
            yield return new WaitForSeconds(0.2f);
            //player going into elevator animation
            playerinput.currentActionMap.Disable();
            elevator.onExit();
            yield return new WaitForSeconds(1f);
            levelchanger.fadeToLevel(SceneManager.GetActiveScene().buildIndex+1);
        }
    }

    private IEnumerator deathPit(float timeToWait)
    {
        camera.transform.parent = null;
        yield return new WaitForSeconds(timeToWait);
        Death();
    }


    public void Death()
    {
        if(isDead == false)
        {
            isDead = true;
            animator.SetBool("IsDead", true);
            animator.SetTrigger("Death");
            levelchanger.fadeToLevel(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void UseTriggerable(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(player.position, 3f, TriggerLayer);
            foreach(Collider2D c in colliders)
            {
                TriggerMechanics triggerScript = c.gameObject.GetComponent<TriggerMechanics>();
                triggerScript.animator.Play("PressButton");
                triggerScript.Trigger();
                return;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(player.position, 5f);
    }

}
