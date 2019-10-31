using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class redT : TankManager
{
   private float speedR;
    private float speedAway;
    public float Critical;
    private int move;
    public float dis;



    private void Awake()
    {
        this.isFire = true;
        move = 1;
        Start();
        speedE = speedT / 1.2f;
        speedAway = speedT * 1.2f;
        
    }


    

    IEnumerator WaitMove()
    {
        move = 2;
        yield return new WaitForSeconds(0.5f);
        StopCoroutine(WaitMove());
        move = 1;


    }

    // Update is called once per frame
    void Update()
    {
        MoveWall();
        moves();

        if (Vector2.Distance(transform.position, target.position) < Critical  )
        {
            StartCoroutine(WaitMove());
        }


        Dead();
    }

    

    public void moves()
    {
        switch (move)
        {
            case 1:
                FindTank();
                break;


            case 2:


                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, -speedAway * Time.deltaTime);
                        ShootT();
                 break;
        }
    }
}
