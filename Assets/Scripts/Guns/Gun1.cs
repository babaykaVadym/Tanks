using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun1 : Gun
{
  
 
    public override void Update()
    {
        Rotation();
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("gun1B");
        if (gos.Length!= 1)
        {

                      if (isFire)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {

                    Shoot();
                }
            }
        }
        else
        {
            isFire = true;
        }

        if (isFire)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                Shoot();
            }
        }

    }



    public override void Shoot()
    {


        foreach (Transform sp in shootPoits)
        {
            GameObject b = Instantiate(bullet, sp.position, transform.rotation) as GameObject;
            b.GetComponent<Rigidbody2D>().AddForce(b.transform.up * speedBul * 10);
            b.gameObject.tag = "gun1B";
            if (sp == shootPoits[shootPoits.Length - 1])
            {

                StartCoroutine(ShootsDilay());
            }
        }
        isFire = false;


    }




    IEnumerator ShootsDilay()
    {

        yield return new WaitForSeconds(shootTimes);

    }


}

