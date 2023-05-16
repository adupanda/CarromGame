using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public int PlayerPointCount = 0;

    public int EnemyPointCount = 0;

    public Text PlayerPoints;

    public Text EnemyPoints;

    public GameFlow gameflowref;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coins" | collision.gameObject.tag == "White Coin" | collision.gameObject.tag == "Black Coin")
        {
            Destroy(collision.gameObject);
            
        }
        if (collision.gameObject.tag == "Coins")
        {
            if(gameflowref.PlayerTurn)
            {
                PlayerPointCount += 2;
                PlayerPoints.text = PlayerPointCount.ToString(); 
            }
            else if(gameflowref.EnemyTurn)
            {
                EnemyPointCount += 2;
                EnemyPoints.text = EnemyPointCount.ToString();
            }
        }
        else if(collision.gameObject.tag == "White Coin")
        {
            PlayerPointCount += 1;
            PlayerPoints.text = PlayerPointCount.ToString();
        }
        else if(collision.gameObject.tag == "Black Coin")
        {
            EnemyPointCount += 1;
            EnemyPoints.text = EnemyPointCount.ToString();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
