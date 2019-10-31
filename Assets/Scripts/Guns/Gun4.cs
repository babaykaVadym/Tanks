using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun4 : MonoBehaviour
{


    public Transform shootPoit1;
    public Transform shootPoit2;
    public Transform shootPoit3;
    public Transform shootPoit4;
    public GameObject bullet;
    public bool isFire;
    public bool isReadyShoots;
    public float shootTimes;

    public float speedBul;


    public float speedRotation = 2f;
    private Vector2 mousePos, objPos, direction, currentDir;

    void Start()
    {
        isReadyShoots = false;
        isFire = true;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            isReadyShoots = true;
        }

        Rotation();

        if (isFire && isReadyShoots)
        {
    
            Shoot();
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

    public void Fire(bool fire)
    {
        isFire = fire;
    }

    void Shoot()
    {
        

        GameObject b = Instantiate(bullet, shootPoit1.position, transform.rotation) as GameObject;
            b.GetComponent<Rigidbody2D>().AddForce(b.transform.up * speedBul * 10);

        GameObject b2 = Instantiate(bullet, shootPoit2.position, transform.rotation) as GameObject;
        b2.GetComponent<Rigidbody2D>().AddForce(-b2.transform.up * speedBul* 1.5f * 10);

        GameObject b3 = Instantiate(bullet, shootPoit3.position, transform.rotation) as GameObject;
        b3.GetComponent<Rigidbody2D>().AddForce(b3.transform.right * speedBul * 10);

        GameObject b4 = Instantiate(bullet, shootPoit4.position, transform.rotation) as GameObject;
        b4.GetComponent<Rigidbody2D>().AddForce(-b4.transform.right * speedBul * 10);

        b.gameObject.tag = "gun4B";
        b2.gameObject.tag = "gun4B";
        b3.gameObject.tag = "gun4B";
        b4.gameObject.tag = "gun4B";
        StartCoroutine(ShootsDilay());
            

        
    }

    IEnumerator ShootsDilay()
    {
        isReadyShoots = false;
        yield return new WaitForSeconds(shootTimes);
        isReadyShoots = true;
    }
}
