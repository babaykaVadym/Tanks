using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yellowTank : TankManager
{
    private Vector2 moveDirection;
    private Vector3 rotation;
    private float speedY;
    private int move;
    public float FireTime;
    public float minMoveTime;
    public float maxMoveTime;
    public bool GoTank = false;


    // Start is called before the first frame update
    private void Awake()
    {
        this.isFire = true;
        GoTank = false;
        Start();
        speedE = speedT / 1.25f;
        StartCoroutine(WaitMove(Random.Range(minMoveTime, maxMoveTime)));
    }
   

    IEnumerator WaitMove(float t)
    {
        GoTank = false;
        InvokeRepeating("choseMove", 0, 1.15f);
        yield return new WaitForSeconds(Random.Range(minMoveTime, maxMoveTime));
        StopCoroutine(WaitMove(0));
        GoTank = true;
        yield return new WaitForSeconds(FireTime);
        GoTank = false;
        StartCoroutine(WaitMove(Random.Range(minMoveTime, maxMoveTime)));
    }


    private void choseMove()
    {
        move = Random.Range(1, 4);
    }


    void Update()
    {
        MoveWall();

        if (!GoTank) { Moves(); }
        else
        {
             FindTank();
            ShootT();
        }

        Dead();
    }
                 
   public void Moves()
    {
        switch (move)
        {
            case 1:
                moveDirection = new Vector2(0, 1);
                rotation = new Vector3(0, 0, 0);
                break;

            case 2:
                moveDirection = new Vector2(0, -1);
                rotation = new Vector3(0, 0, 180);
                 break;

            case 3:
                moveDirection = new Vector2(-1, 0);
                rotation = new Vector3(0, 0, 90);
                break;

            case 4:
                moveDirection = new Vector2(1, 0);
                rotation = new Vector3(0, 0, -90);
                break;
         
        }
        tank.localRotation = Quaternion.Euler(rotation);

        body.AddForce(moveDirection * speedE * 13f);
    }
}
