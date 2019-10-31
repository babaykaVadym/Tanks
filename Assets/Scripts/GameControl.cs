using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameControl : MonoBehaviour
{

    public int prevScore;
    public int NewScore;
    public Text prevScoreT, NewScoreT;

    public float speed = 2f;
    [HideInInspector]
    public static bool playerDead;
    public static int score;
    public GameObject greenT;
    public GameObject yellowT;
    public GameObject[] T;
    public float enemySpawnTime;
    [HideInInspector]
    public int maxEnemy;
    public Transform playerSpawn;
    public GameObject player;
    public Text scoreCountT;
    [HideInInspector]
    public int scoreCount;
    [HideInInspector]
    public static int enemyCount;

    private int Life_points;

    public float minTX, maxTX, minTY, maxTY;

        private int creator;

    public Image[] lifePoins;
    public Color[] colors;
    public GameObject gameOverPanel;
    void Start()
    {
        

        Life_points = 3;
        prevScore = PlayerPrefs.GetInt("PS", 0);
        NewScore = PlayerPrefs.GetInt("NS", 0);
        enemyCount = 0;
        playerDead = false;
        score = 0;
        Instantiate(player, playerSpawn.position, Quaternion.identity);
        creator = 1;
     }

    void Save()
    {
        PlayerPrefs.SetInt("NewScore", scoreCount);
        if (!PlayerPrefs.HasKey("PS"))
        {
            PlayerPrefs.SetInt("PS", prevScore);
        }
        else
        {
            int hs = PlayerPrefs.GetInt("NS");
            PlayerPrefs.SetInt("PS", scoreCount);
        }

    }


    void ChangeLife()
    {
        for (int i = 0; i < lifePoins.Length; i++)
        {
            if (i < Life_points)
            {
                lifePoins[i].color = colors[0];
            }
            else
            {
                lifePoins[i].color = colors[1];
            }
        }
    }


    public void createTank()
    {
        switch (creator)
        {
            case 1:
                for (int i = 0; i < 5; i++)
                {

                    Vector2 pos = new Vector3(Random.Range(minTX, maxTX), Random.Range(minTY, maxTY), 0);
                    Instantiate(greenT, pos, Quaternion.identity);
                    enemyCount++;
                }
                creator = 2;
                break;

            case 2:
                for (int i = 0; i < 5; i++)
                {
                    Vector2 pos = new Vector3(Random.Range(minTX, maxTX), Random.Range(minTY, maxTY), 0);
                    Instantiate(yellowT, pos, Quaternion.identity);
                    enemyCount++;
                }
                
                creator = 3;
                break;

            case 3:

                foreach (GameObject sp in T)
                {

                    Vector2 pos = new Vector3(Random.Range(minTX, maxTX), Random.Range(minTY, maxTY), 0);
                    Instantiate(sp, pos, Quaternion.identity);
                    enemyCount++;
                }
                    break;
        }
        
    }

void GameOver()
    {
        Save();
        gameOverPanel.SetActive(true);

    }



    void Update()
    {
        
        prevScoreT.text = "Previous score: " + prevScore;
        NewScoreT.text = "New score: " + scoreCount;
       
        scoreCountT.text = scoreCount.ToString();
        NewTank();

       
            Dead();
            
        
        if(Life_points == 0)
        {
            var objs = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < objs.Length; i++)
                Destroy(objs[i]);
            GameOver();

        }

    }



    void Dead()
    {
  


        if (playerDead)
            {
                Life_points--;
                ChangeLife();
                playerDead = false;
            if (Life_points > 0)
            {
                Instantiate(player, playerSpawn.position, Quaternion.identity);
            }
        }
        
    }

    public void NewTank()
    {
        if (enemyCount <= 3)
        {
            createTank();
        }
        else if (enemyCount < 4 && creator == 3)
        {
            createTank();
            maxEnemy = Random.Range(7, 10);
        }
        else if (enemyCount < maxEnemy && creator == 3)
        {
            maxEnemy = Random.Range(7, 10);
            createTank();
        }
    }

    public void AddScore(int scoreAdd)
    {
        scoreCount += scoreAdd;
    }
}
