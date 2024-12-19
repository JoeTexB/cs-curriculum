using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;







public class PlayerController : MonoBehaviour
{
    GameManager gm;

    public bool phase;
    public float phaseTimer;
    public SpriteRenderer playerRenderer;
    public float xspeed;
    float xdirection;
    public float xvector;

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

    private Collider2D col;
    private float thrust;
    private bool isGrounded = true;

    public float jumpcooldown;

    private void Start()
    {
        isGrounded = true;

        gm = FindObjectOfType<GameManager>();

        //Enemy = FindObjectOfType<Enemy>();

        tda = FindObjectOfType<TopDown_AnimatorController>();

        playerRenderer = GetComponentInChildren<SpriteRenderer>();

        xspeed = 4f;
        xdirection = 0;
        xvector = 0;

        col = GetComponent<Collider2D>();

        yspeed = 4f;
        ydirection = 0;
        yvector = 0;

        thrust = 0.09f;


        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();

        PlayerAttack = false;

        GetComponentInChildren<TopDown_AnimatorController>().enabled = overworld;
        GetComponentInChildren<Platformer_AnimatorController>().enabled = !overworld; //what do you think ! means?


        if (overworld)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0f;
        }
        else
        {

            GetComponent<Rigidbody2D>().gravityScale = 0.5f;
        }

    }



    private void Update()
    {

        jumpcooldown -= Time.deltaTime;

        //color change on lever
        phaseTimer -= Time.deltaTime;
        if (phaseTimer <= 0)
        {
            phase = false;
        }

        if (phase)
        {
            playerRenderer.color = new Color(1, 1, 1, .1f);
            xspeed = 8f;
        }

        if (phase == false)
        {
            playerRenderer.color = new Color(1, 1, 1, 1f);
            xspeed = 4f;
        }

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
        
        // UpdateGroundedStatus();
        //Debug.Log(isGrounded);

        if (!overworld)
        {
            //print("Player is not overworld");

            //yspeed = 0;

            // UpdateGroundedStatus();

            //  if (Input.GetKey(KeyCode.Space) && jumpcooldown < 0 && isGrounded == true)
            //{
                // jumpcooldown = 1 * Time.deltaTime;
                //print("Space");
                //  if (Physics2D.Raycast(
                //new Vector2(transform.position.x + col.bounds.extents.x,
                //                    transform.position.y - col.bounds.extents.y), Vector2.down, 2f) ||
                //            Physics2D.Raycast(
                //                new Vector2(transform.position.x + + col.bounds.extents.x,
                // transform.position.y - col.bounds.extents.y), Vector2.down, 2f))
                //        {
                //            print("jump");

                //            rb.AddForce(Vector2.up * thrust, ForceMode2D.Impulse); 
                //            Debug.DrawRay(transform.position, Vector2.down, Color.green);
                //            Debug.DrawRay(transform.position, Vector2.down, Color.green);
                //        }
                //    }




                // }

            //}

            //void UpdateGroundedStatus()
            //{
            //    Vector2 raycastOrigin = GetGroundCheckOrigin();
            //    isGrounded = Physics2D.Raycast(raycastOrigin, Vector2.down, 0.23f);
            //}

            //Vector2 GetGroundCheckOrigin()
            //{
            //    return new Vector2(transform.position.x + col.bounds.extents.x, transform.position.y - col.bounds.extents.y);
            //}
            

            



            //for organization, put other built-in Unity functions here







            //after all Unity functions, your own functions can go here

            
        }
        if (Input.GetKey(KeyCode.H))
        {
            if (gm.coins>0)
            {
                gm.health += 2;
                gm.coins -= 1;
            }

            
        }
    }
    
    void OnTriggerStay2D(Collider2D other)
    {
        //print("Touching ");
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy = other.gameObject.GetComponent<Enemy>();
                    
            //print("Touching enemy");

            if (PlayerAttack)
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

    void OnCollisionStay2D(Collision2D other)
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
    
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            PlayerAttack = false;
            print("PlayAttack:" + PlayerAttack);
        }
    }
}