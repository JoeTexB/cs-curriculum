using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;







public class PlayerController : MonoBehaviour
{
    GameManager gm;


    float xspeed;
    float xdirection;
    float xvector;

    float yspeed;
    float ydirection;
    float yvector;
     
    private float EnemyDmgCoolDown = 1f;
    private float AttackCoolDown = 1f;

    
    
    public bool overworld;
    Rigidbody2D rb;

    public Enemy Enemy;
    public TopDown_AnimatorController tda;
    public bool PlayerAttack;
    

    private void Start()
    {

        gm = FindObjectOfType<GameManager>();

        Enemy = FindObjectOfType<Enemy>();

        tda = FindObjectOfType<TopDown_AnimatorController>();
        
        

        xspeed = 4f;
        xdirection = 0;
        xvector = 0;

        

        yspeed = 4f;
        ydirection = 0;
        yvector = 0;

        PlayerAttack = false;

        GetComponentInChildren<TopDown_AnimatorController>().enabled = overworld;
        GetComponentInChildren<Platformer_AnimatorController>().enabled = !overworld; //what do you think ! means?
        
        
        if (overworld)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0f;
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

    

    private void Update()
    {
        



        xdirection = Input.GetAxis("Horizontal");
        xvector = xspeed * xdirection;

        ydirection = Input.GetAxis("Vertical");
        yvector = yspeed * ydirection;

        //working 
        transform.Translate(Time.deltaTime * xvector, Time.deltaTime * yvector, 0);

        EnemyDmgCoolDown -= Time.deltaTime;
        AttackCoolDown -= Time.deltaTime;

        if (PlayerAttack == true)
        {
            if (AttackCoolDown < -0.5)
            {
                PlayerAttack = false;
                print("PlayerAttack:" + PlayerAttack);
                AttackCoolDown = 1f;
            }
        }
    }

    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //damaging enemy (edited "==" statement, if don't work revert to "=") 
            if (PlayerAttack == true)
            {
                if (EnemyDmgCoolDown < 0)
                {
                    Enemy.EnemyHealth -= 1;
                    EnemyDmgCoolDown = 1f;
                    print("Enemy health:" + Enemy.EnemyHealth);
                }
                
            }
            
        }
        
        //picking up axe
        if (other.gameObject.CompareTag("Axe"))
        {
            //Making pause before cooldown
            if (EnemyDmgCoolDown < -1)
            {
                tda.SwitchToAxe();
                Destroy(other.gameObject);
            }
            
        }
        
        
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        //colliding with door
        if (other.gameObject.CompareTag("WoodDoor"))
        {
            print("door work 1");
            if (tda.usingaxe == true)
            {
                print("door work 2");
                if (PlayerAttack == true)
                {
                    print("door work 3");
                    print("Destroying wooden door");
                    Destroy(other.gameObject);
                }
                
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            PlayerAttack = false;
            print("PlayAttack:" + PlayerAttack);
        }
    }

    //for organization, put other built-in Unity functions here



   
    
    

    //after all Unity functions, your own functions can go here

}