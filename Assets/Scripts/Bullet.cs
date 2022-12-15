using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    //public PlayerManager playerManager;

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
        if (col.gameObject.tag == "Player")
        {
            GameObject Player = GameObject.Find("Player");
            PlayerManager playerManager = Player.GetComponent<PlayerManager>();
            playerManager.Death();
        }
    }


}
