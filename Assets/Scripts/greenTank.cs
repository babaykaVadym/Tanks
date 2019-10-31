using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class greenTank : TankManager
{
   
 //   public GameControl TankS;

    private float speedG;

    private void Awake()
    {
        this.isFire = true;
        Start();
        speedE = speedT / 1.4f;

    }




    void Update()
    {
        ChangeLife();

        FindTank();
        
        Dead();
    }


    
}
