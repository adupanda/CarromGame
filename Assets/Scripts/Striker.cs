using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Striker : MonoBehaviour
{
    public Rigidbody2D selfRB;

    Transform selfTransform;

    Vector2 startPos;

    public Slider strikerSlider;

    Vector2 direction;

    Vector3 mousepos;

    Vector3 mousepos2;

    //public LineRenderer lineRenderer;

    public Transform Arrow;

    public bool hasHit = false;

    public bool positionSet = false;

    public GameFlow gameflowref;

    bool EnemyShot;


    

    // Start is called before the first frame update
    void Start()
    {
        selfRB = GetComponent<Rigidbody2D>();
        selfTransform = transform;
        startPos = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        Arrow.GetComponent<SpriteRenderer>().enabled = false;
        //lineRenderer.enabled = false;
        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousepos2 = new Vector3 (-mousepos.x,-mousepos.y, mousepos.z);

        if (!hasHit && !positionSet )
        {
            if(gameflowref.PlayerTurn)
            {
                selfTransform.position = new Vector2(strikerSlider.value, startPos.y);
            }
            else if(gameflowref.EnemyTurn)
            {
                selfTransform.position = new Vector2(0f, 1.8f);
            }
            
        }
        if(gameflowref.PlayerTurn)
        {
            if (Input.GetMouseButtonUp(0) && selfRB.velocity.magnitude == 0 && positionSet)
            {
                shootStriker();
            }
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            
            if (hit.collider.name == "striker" && selfRB.velocity.magnitude == 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (!positionSet)
                    {
                        positionSet = true;
                    }
                }
            }
            if (positionSet && selfRB.velocity.magnitude == 0)
            {
                //lineRenderer.enabled = true;
                //lineRenderer.SetPosition(0, selfTransform.position);
                //lineRenderer.SetPosition(1, mousepos2);
                Arrow.GetComponent<SpriteRenderer>().enabled = true;
                float angle = Mathf.Atan2(mousepos.y - transform.position.y, mousepos.x - transform.position.x) * Mathf.Rad2Deg;
                Arrow.rotation = Quaternion.Euler(0, 0, angle + 180);
                float ArrowScale = Mathf.Clamp(Vector2.Distance(transform.position, mousepos), 0, 1);
                Arrow.localScale = new Vector3(ArrowScale * 10, ArrowScale * 10, ArrowScale * 10);

            }
        }
        else if(gameflowref.EnemyTurn)
        {
            if(!EnemyShot)
            {
                Invoke("EnemyShootStriker", 2);
                EnemyShot = true;
            }
            
            
        }
        
        
        


        if (selfRB.velocity.magnitude < 0.2f && selfRB.velocity.magnitude !=0)
        {
            strikerReset();
        }
        
    }

    public void shootStriker()
    {
        float Force = Mathf.Clamp(Vector2.Distance(transform.position, mousepos), 0, 1)*400;
        Vector2 Direction = new Vector2(transform.position.x-mousepos.x,transform.position.y-mousepos.y);
        Direction.Normalize();
        selfRB.AddForce(Direction*Force);
        EnemyShot = false;
    }

    void EnemyShootStriker()
    {
        Transform RandomCoin = gameflowref.BlackCoins[Random.Range(0,gameflowref.BlackCoins.Length)].transform;

        Vector2 Direction = new Vector2(RandomCoin.position.x - transform.position.x,RandomCoin.position.y - transform.position.y);
        Direction.Normalize();
        float Force = Random.Range(25f, 75f);
        Vector2 FinalForce = Direction * Force;
        selfRB.AddForce(FinalForce);
        
    }

    public void strikerReset()
    {
        gameflowref.TurnSwitcher();
        selfRB.velocity = Vector2.zero;
        hasHit = false;
        positionSet = false;
        
    }
   
}
