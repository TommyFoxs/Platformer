using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTexture : MonoBehaviour
{
    
    private Animator animator;
    
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        StartCoroutine(startAnimation());
    }

    IEnumerator startAnimation()
    {
        float randomNumber = Random.Range(0f, 1f);
        yield return new WaitForSeconds(randomNumber);
        animator.SetTrigger("whenTo");

    }
}
