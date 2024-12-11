using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class Enemy : MonoBehaviour
{
    public List <Vector3> waypoints;

    private int num;
    public TopDown_EnemyAnimator _controller;
    public Health HealthManager;
    public int EnemyHealth = 3;
    public bool overworld;

    public GameObject Axe;

    
   
    enum states
    {
        patrol,
        chase,
        attack,
    }
    private states state;
                                                                     
    public Vector3 PlayerTargetPosition;
    // Start is called before the first frame update
    void Start()
    {
        state = states.patrol;
        HealthManager = FindObjectOfType<Health>();
        
        GetComponent<Rigidbody2D>().gravityScale = 0f;
        
        
        //if (overworld)
        //{
        //     GetComponent<Rigidbody2D>().gravityScale = 0f;
        //}
        //else
        //{
            
        //    GetComponent<Rigidbody2D>().gravityScale = 1f;
        //}
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           
            
            if (state == states.patrol && state != states.attack)
            {
                state = states.chase;
                print("Chasing");
            }
            
            
            
            PlayerTargetPosition = other.transform.position;
           
            
            
        }
        
    }
    
    //exiting attack radius and returning to proper state
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            print("Player exited radius");
            if (state == states.chase)
            {
                print("returning to patrol");
                state = states.patrol;
            }
        }
    }

    //making attack animation frm topdownenemy script and health
    
    public void attack()
    {
        print("attacking damage");
        _controller.Attack();
        HealthManager.takedmg();
    }


    // Update is called once per frame
    void Update()
    {
        //attacking trigger without radius
        if (Vector3.Distance(transform.position, PlayerTargetPosition) < 2 && state == states.chase) 
        {
            print("Attacking");
            state = states.attack;
            
        }
        if (Vector3.Distance(transform.position, PlayerTargetPosition) > 2 && state == states.attack)
        {
            state = states.chase;
            print("chase");
        }
        
        
        //patrol (Follow waypoints)
        if (state == states.patrol)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[num], 2 * Time.deltaTime);
        }

        //chase player
        if (state == states.chase)
        {
            transform.position = Vector3.MoveTowards(transform.position, PlayerTargetPosition, 2 * Time.deltaTime);
            
        }

        if (state == states.attack)
        {
            transform.position = Vector3.MoveTowards(transform.position, PlayerTargetPosition, 2 * Time.deltaTime);
            attack();
            
        }
       
        //waypoints change
        if (overworld)
        {
            if (transform.position == waypoints[num])
            {
                num += 1;
                if (num > 6)
                {
                    num = 0;
                }
            }
        }
        else 
        if (transform.position == waypoints[num])
        {
            num += 1;
            if (num > 1)
            {
                num = 0;
            }
        }


        //If enemy dies
        if (EnemyHealth < 1)
        {
            print("Enemy die");
            Instantiate(Axe, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        

        //return to patrol
        if (transform.position == PlayerTargetPosition)
        {
            state = states.patrol;
            print("Target pos reached, returning to patrol");
        }

    }
    
}
        
