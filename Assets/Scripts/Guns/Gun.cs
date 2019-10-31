using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform[] shootPoits;
    public GameObject bullet;
    [HideInInspector]
    public bool isFire;
    [HideInInspector]
    public bool isReadyShoots;
    public float shootTimes;

    public float speedBul;


    public float speedRotation=2f;
    [HideInInspector]
    public Vector2 mousePos, objPos, direction, currentDir;

    void Start()
    {
        isReadyShoots = true;
        isFire = true;
        
    }

    public virtual void Update()
    {
     
            Rotation();
        
        if (isFire && isReadyShoots)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                Shoot();
            }

        }

    }


    public void Rotation()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        objPos = transform.position;
        direction = mousePos - objPos;
        direction.Normalize();
        currentDir = Vector2.Lerp(currentDir, direction, Time.deltaTime * speedRotation);
        transform.up = currentDir;

    }

    public virtual void Shoot()
        {


        foreach (Transform sp in shootPoits)
        {
            GameObject b = Instantiate(bullet, sp.position, transform.rotation) as GameObject;
            Destroy(b, 6);

            b.GetComponent<Rigidbody2D>().AddForce(b.transform.up * speedBul*10);
            b.gameObject.tag = "gun1B";
            Destroy(b, 7);
            if (sp == shootPoits[shootPoits.Length - 1])
            {

                StartCoroutine(ShootsDilay());
            }
        
        }
    }

    IEnumerator ShootsDilay()
    {
        isReadyShoots = false;
        yield return new WaitForSeconds(shootTimes);
        isReadyShoots = true;
    }
}
