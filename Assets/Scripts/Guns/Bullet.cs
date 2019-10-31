using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int damage;

  
    private void Start()
    {

    }

    public void Update()
    {
        if (gameObject.tag == "gun1B" || gameObject.tag == "bulletE")
        {
            damage = 2;


        }
        
        else if (gameObject.tag == "gun4B")
        {
            damage = 1;
        }

    }


    void OnTriggerEnter2D(Collider2D coll)
    {


        if (coll.transform.CompareTag("Enemy"))
        {
            

            TankManager enemy = coll.transform.GetComponent<TankManager>();
            enemy.hp -= damage;
            
            Destroy(gameObject);
            
        }
    }

    void OnBecameInvisible()
    {
                Destroy(gameObject);
    }
}
