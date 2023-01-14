using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public bool hasKeycard = false;
    public GameObject blackOutSquare;
<<<<<<< HEAD
    private bool isSpeaking = false;
=======
>>>>>>> 218d55cef7d846e15475e89bdd94f33d8ee30b11

    public LevelChanger levelchanger;
    public bool isDead = false;
    public Animator animator;
    [SerializeField]
    private LayerMask TriggerLayer;

    [SerializeField]
    private Transform player;
<<<<<<< HEAD
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip deathSound;
=======
>>>>>>> 218d55cef7d846e15475e89bdd94f33d8ee30b11
    Camera camera;


    [SerializeField] private PlayerInput playerinput;

    void Start()
    {
        camera = Camera.main;
<<<<<<< HEAD
        if (MainManager.hasChanged == false)
        {
            MainManager.hasChanged = true;
            MainManager.Volume = 0.5f;
        }
=======
>>>>>>> 218d55cef7d846e15475e89bdd94f33d8ee30b11
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

<<<<<<< HEAD
=======


>>>>>>> 218d55cef7d846e15475e89bdd94f33d8ee30b11
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

<<<<<<< HEAD
    void OnTriggerExit2D(Collider2D col)
    {
        if (isSpeaking == true && col.gameObject.layer == 14)
        {
            animator.SetBool("IsSpeaking", false);
            isSpeaking = false;
        }
    }

=======
>>>>>>> 218d55cef7d846e15475e89bdd94f33d8ee30b11
    private IEnumerator exitLevel(GameObject elevatorObject)
    {
        ElevatorScript elevator = elevatorObject.GetComponent<ElevatorScript>();
        if (elevator.isExit == true)
        {
<<<<<<< HEAD
            int levelIndex = SceneManager.GetActiveScene().buildIndex;
            if (levelIndex != 7 || hasKeycard == true)
            {
                yield return new WaitForSeconds(0.2f);
            //player going into elevator animation
                playerinput.currentActionMap.Disable();
                elevator.onExit();
                yield return new WaitForSeconds(1f);
                levelchanger.fadeToLevel(levelIndex+1);
            }
            else if (isSpeaking == false)
            {
                animator.SetBool("IsSpeaking", true);
                isSpeaking = true;
            }
=======
            yield return new WaitForSeconds(0.2f);
            //player going into elevator animation
            playerinput.currentActionMap.Disable();
            elevator.onExit();
            yield return new WaitForSeconds(1f);
            levelchanger.fadeToLevel(SceneManager.GetActiveScene().buildIndex+1);
>>>>>>> 218d55cef7d846e15475e89bdd94f33d8ee30b11
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
<<<<<<< HEAD
            source.PlayOneShot(deathSound, MainManager.Volume);
=======
>>>>>>> 218d55cef7d846e15475e89bdd94f33d8ee30b11
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
