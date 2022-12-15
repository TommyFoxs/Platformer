using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    private Vector3 pos1; //= new Vector3(-4,0,0);
    private Vector3 pos2; //= new Vector3(4,0,0);
    public Vector3 posDif = new Vector3(4,0,0);

    public float speed = 1.0f;

    public bool isTimed = false;
    public float Timing = 3f;
 
    void Start()
    {
        pos1 = transform.position;
        pos2 = pos1 + posDif;
        if (isTimed == true)
        {
            StartCoroutine(timedMovement(Timing));
        }
    }

    void FixedUpdate()
    {
        if (isTimed == false)
        {
            transform.position = Vector3.Lerp (pos1, pos2, Mathf.PingPong(Time.time*speed, 1.0f));
        }
    }

    private IEnumerator timedMovement(float waitFor)//you can just check if thing is in position then stop
    {
        while (true)
        {
            yield return new WaitForSeconds(waitFor);
            while (Vector2.Distance(transform.position, pos2) > 1)
            {
                Debug.Log("going to pos2");
                yield return new WaitForSeconds(0.05f);
                transform.position = Vector3.Lerp (pos1, pos2, Mathf.PingPong(Time.time*speed, 1.0f));
            }
            yield return new WaitForSeconds(waitFor);
            while (Vector2.Distance(transform.position, pos1) > 1)
            {
                Debug.Log("going to pos1");
                yield return new WaitForSeconds(0.05f);
                transform.position = Vector3.Lerp (pos1, pos2, Mathf.PingPong(Time.time*speed, 1.0f));
            }
        }
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (gameObject.tag == "Moving Platform")
    //     {
    //         Debug.Log("had moving platform tag");
    //         if (collision.gameObject.tag == "Player")
    //         {
    //             if (collision.transform.position.y > transform.position.y)
    //             {
    //                  collision.transform.SetParent(transform);
    //             }
    //         }
    //     }
    // }

    // private void OnCollisionExit2D(Collision2D collision)
    // {
    //     if (gameObject.tag == "Moving Platform")
    //         if (collision.gameObject.tag == "Player")
    //             collision.transform.SetParent(null);
    // }

}
