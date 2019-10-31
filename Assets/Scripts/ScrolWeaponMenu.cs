using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrolWeaponMenu : MonoBehaviour
{
    public GameObject img1;
    public GameObject img2;
    public GameObject img3;

   
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("gun1");
        if (gos.Length != 0)
        {
            img1.SetActive(true);
            img2.SetActive(false);
            img3.SetActive(false);
        }

        gos = GameObject.FindGameObjectsWithTag("gun2");
        if (gos.Length != 0)
        {
            img1.SetActive(false);
            img2.SetActive(true);
            img3.SetActive(false);
        }


        gos = GameObject.FindGameObjectsWithTag("gun3");
        if (gos.Length != 0)
        {
            img1.SetActive(false);
            img2.SetActive(false);
            img3.SetActive(true);
        }



        //if (ScrolInt == 0)
        //{
        //    img1.SetActive(true);
        //    img2.SetActive(false);
        //    img3.SetActive(false);
        //}
        //if (ScrolInt == 1)
        //{

        //    img1.SetActive(false);
        //    img2.SetActive(true);
        //    img3.SetActive(false);
        //}
        //if (ScrolInt == 2)
        //{
        //    img1.SetActive(false);
        //    img2.SetActive(false);
        //    img3.SetActive(true);

    }
}

