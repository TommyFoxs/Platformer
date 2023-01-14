using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggerable : MonoBehaviour
{
    [SerializeField] private bool isHorizontal;
    [SerializeField] private float moveAmount;
    [SerializeField] private float moveTime;

    private Vector2 origin;
    private Vector2 Destination;

    public bool isActive = false;
    private bool isMoving;

    void Start()
    {
        origin = gameObject.transform.position;
    }

    public void activateDoor()
    {
        if(isHorizontal == false)
        {
            if(isMoving == false)
            {
                isMoving = true;
                origin = gameObject.transform.position;
                StartCoroutine(moveObject(moveAmount*1.4f, isActive));
                if(isActive)
                {
                    isActive = false;
                }
                else
                {
                    isActive = true;
                }
            }
        }

    }

    public IEnumerator moveObject(float amountToMove, bool isAct)//add ishorizontal bool here
    {
        if(isAct)
        {
            Destination = new Vector2(origin.x, origin.y - amountToMove);
        }
        else
        {
            Destination = new Vector2(origin.x, origin.y + amountToMove);
        }
        float totalMovementTime = moveTime; //the amount of time you want the movement to take
        float currentMovementTime = 0f;//The amount of time that has passed
        while (Vector2.Distance(transform.localPosition, Destination) > 0) {
            currentMovementTime += Time.deltaTime;//grows per frame
            transform.localPosition = Vector2.Lerp(origin, Destination, currentMovementTime / totalMovementTime);// last argument is from 0 to 1, 0 being origin and 1 being destination
            yield return null;
        if (Vector2.Distance(transform.localPosition, Destination) == 0)
        {
            isMoving = false;
        }
    }
}

}
