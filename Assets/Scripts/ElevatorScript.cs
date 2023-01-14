using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    public bool isExit;
    [SerializeField] private Animator animator;

    /*/void Start()
    {
        if (isExit == true)
        {
            animator.Play("ElevatorClose");
        }
    }/*/

    public void onExit()
    {
        animator.Play("ElevatorOpen");
    }


}
