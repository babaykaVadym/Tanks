using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tank : GameControl
{

    public int HP = 20;
    public Transform tank;
    public GameObject gun;
    private Rigidbody2D body;
    private Vector2 moveDirection;
    private Vector3 rotation;


    public Image[] HPPoins;
    private Vector4 Color = new Vector4(0, 0, 0, 1);


    void Start()
    {
       
        body = GetComponent<Rigidbody2D>();
    }

    void ChangeLife()
    {
        for (int i = 0; i < HPPoins.Length; i++)
        {

            if (i < HP)
            {
                
            }
            else
            {
                HPPoins[i].GetComponent<Image>().color = Color;
            }
                       
        }
    }


    void Update()
    {
        Move();
    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.CompareTag("bulletE"))
        {
            HP --;

            ChangeLife();
        }
    }

    public void Move()
    {

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection = new Vector2(0, 1);
            rotation = new Vector3(0, 0, 0);

        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveDirection = new Vector2(0, -1);
            rotation = new Vector3(0, 0, 180);

        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveDirection = new Vector2(-1, 0);
            rotation = new Vector3(0, 0, 90);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveDirection = new Vector2(1, 0);
            rotation = new Vector3(0, 0, -90);

        }
        else
        {
            moveDirection = new Vector2(0, 0);

        }

        tank.localRotation = Quaternion.Euler(rotation);

        body.AddForce(moveDirection * speed*12);


        if (transform.position.x < -8.86)
            transform.position = new Vector3(transform.position.x + 18f, transform.position.y, transform.position.z);
        else if (transform.position.x > 8.86)
            transform.position = new Vector3(transform.position.x - 18f, transform.position.y, transform.position.z);
        if (transform.position.y < -5)
            transform.position = new Vector3(transform.position.x, transform.position.y +9, transform.position.z);
        else if (transform.position.y > 4.3)
            transform.position = new Vector3(transform.position.x, transform.position.y-9, transform.position.z);
        if (HP <= 0)
        {
            GameControl.playerDead = true;
            float randomZ = Random.Range(0, 360f);
          
            Destroy(gameObject);
        }
    }

      
}
