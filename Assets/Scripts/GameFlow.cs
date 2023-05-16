using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameFlow : MonoBehaviour
{
    

    public bool PlayerTurn = true;

    public bool EnemyTurn = false;

    public GameObject[] BlackCoins;

    public float timeValue = 120;

    public Text timetext;

    public Text gameOver;
    void Start()
    {
        BlackCoins = GameObject.FindGameObjectsWithTag("Black Coin");
    }

    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
            gameOver.enabled = false;
        }
        else
        {
            gameOver.enabled = true;
            timeValue = 0;

            
        }

        TimeDisplay(timeValue);
        
    }

    void TimeDisplay(float timeToDisplay)
    {
        if(timeToDisplay < 0 )
        {
            timeToDisplay = 0;
        }
        float minutes = Mathf.FloorToInt(timeToDisplay/ 60);
        float seconds = Mathf.FloorToInt(timeToDisplay%60);

        timetext.text = string.Format("{0:00}:{1:00}",minutes,seconds);
    }

    void EndGame()
    {

    }
    public void TurnSwitcher()
    {
        if (PlayerTurn)
        {
            PlayerTurn = false;
            EnemyTurn = true;
        }
        else
        {
            PlayerTurn = true;
            EnemyTurn = false;
        }
    }
   
}
