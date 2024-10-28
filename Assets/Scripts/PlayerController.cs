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
    
    
    public bool overworld;
    Rigidbody2D rb;

    public Enemy Enemy;
    public bool PlayerAttack;

    private void Start()
    {

        gm = FindObjectOfType<GameManager>();

        Enemy = FindObjectOfType<Enemy>();

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
    }

    //damaging enemy
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (PlayerAttack = true)
            {
                if (EnemyDmgCoolDown < 0)
                {
                    Enemy.EnemyHealth -= 1;
                    EnemyDmgCoolDown = 1f;
                    print("Enemy health:" + Enemy.EnemyHealth);
                }
                
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            PlayerAttack = false;
        }
    }

    //for organization, put other built-in Unity functions here



   
    
    

    //after all Unity functions, your own functions can go here

}