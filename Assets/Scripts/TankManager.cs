using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankManager : MonoBehaviour
{
   
    public int hp=3;
    public int score;
    [HideInInspector]
    public float speedT;

    [HideInInspector]
    public float speedE;
    [HideInInspector]
    public Rigidbody2D body;
    public Transform[] shootPoits;
    public GameObject bullet;
    [HideInInspector]
    public bool isFire;
    public float shootTimes;

    public float seeDistance;
    public float attackDistance;
    public Transform target;
    public Transform tank;
    public float speedBul;
    public GameControl gm;

    public Image[] HPPoins;
    public Vector4 Color = new Vector4(0, 0, 0, 1);

    public void Start()
    {
        
        body = GetComponent<Rigidbody2D>();
        gm = GameObject.Find("GameControl").GetComponent<GameControl>();
        speedT = gm.speed;
    }

    public void ChangeLife()
    {
        for (int i = 0; i < HPPoins.Length; i++)
        {

            if (i < hp)
            {

            }
            else
            {
                HPPoins[i].GetComponent<Image>().color = Color;
            }

        }
    }

    public void Dead()
    {
        if (hp <=0)
        {
            GameControl.enemyCount--;
            gm.GetComponent<GameControl>().AddScore(score);
            float randomZ = Random.Range(0, 360f);

            Destroy(gameObject);
            
        }


    }


    public void FindTank()
    {
        target = GameObject.FindWithTag("Player").transform;


        if (Vector2.Distance(transform.position, target.position) <= seeDistance)
        {
            var turn = Quaternion.Lerp(tank.rotation, Quaternion.LookRotation(Vector3.forward, target.position - tank.position), Time.deltaTime * 8f);
            body.MoveRotation(turn.eulerAngles.z);
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speedE * Time.deltaTime);

            if (Vector3.Distance(transform.position, target.transform.position) < attackDistance)
            {

                ShootT();

            }
        }
    }



    public void MoveWall()
    {
        if (transform.position.x < -8.86)
            transform.position = new Vector3(transform.position.x + 18f, transform.position.y, transform.position.z);
        else if (transform.position.x > 8.86)
            transform.position = new Vector3(transform.position.x - 18f, transform.position.y, transform.position.z);
        if (transform.position.y < -5)
            transform.position = new Vector3(transform.position.x, transform.position.y + 9, transform.position.z);
        else if (transform.position.y > 4.3)
            transform.position = new Vector3(transform.position.x, transform.position.y - 9, transform.position.z);
    }
    public void ShootT()
    {
       
        if (isFire)
        {
            isFire = false;
            foreach (Transform sp in shootPoits)
            {
                GameObject b = Instantiate(bullet, sp.position, transform.rotation) as GameObject;
                b.GetComponent<Rigidbody2D>().AddForce(b.transform.up * speedBul * 10);
                b.gameObject.tag = "bulletE";
                StartCoroutine(WaitFire(shootTimes));
            }
            
        }
    }
    IEnumerator WaitFire(float t)
    {
        isFire = false;
        yield return new WaitForSeconds(shootTimes);
        isFire = true;
        //StartCoroutine(WaitFire(shootTimes));
    }
       
}

