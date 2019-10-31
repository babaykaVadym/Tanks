using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullEnemy : Bullet
{


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.CompareTag("Player"))
        {

            Destroy(gameObject);
        }
    }
}
