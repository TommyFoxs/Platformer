using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMechanics : MonoBehaviour
{
    [SerializeField]
    private Transform Player;
    public Animator animator;

    [SerializeField] private GameObject toTrigger;
    private Triggerable triggerable;

    private bool isHidden = true;
    private bool isShown = false;

    void Start()
    {
        triggerable = toTrigger.GetComponent<Triggerable>();
    }

    void Update()
    {
        ShowKey();
    }

    void ShowKey()
    {
        float distance = Vector2.Distance (Player.position, gameObject.transform.position);
        if (distance >= 3f)
        {
            if(isHidden == false)
            {
                animator.Play("HideKey");
                isShown = false;
                isHidden = true;
            }
        }
        else if (distance <= 3f)
        {
            if(isShown == false)
            {
                animator.Play("ShowKey");
                isHidden = false;
                isShown = true;
            }
        } 
    }

    public void Trigger()
    {
        triggerable.activateDoor();
    }

}

