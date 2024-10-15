using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public List <Vector3> waypoints;

    private int num;
   
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
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            state = states.chase;
            
            
            PlayerTargetPosition = other.transform.position;
           
            //entering attack radius
            if (state == states.chase)
            {
                state = states.attack;
                print("attacking");
            }
        }
        
    }

    //exiting attack radius
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            if (state == states.attack)
            {
                state = states.chase;
            }
            
        }
    }


    // Update is called once per frame
    void Update()
    {
        //follow waypoints
        if (state == states.patrol)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[num], 2 * Time.deltaTime);
        }

        //waypoints change
        if (transform.position == waypoints[num])
        {
            num += 1;
            if (num > 6)
            {
                num = 0;
            }
        }
        
        //attack player
        if (state == states.attack)
        {
            transform.position = Vector3.MoveTowards(transform.position, PlayerTargetPosition, 2 * Time.deltaTime);
        }

        //chase player
        if (state == states.chase)
        {
            transform.position = Vector3.MoveTowards(transform.position, PlayerTargetPosition, 2 * Time.deltaTime);
            
        }

        //return to patrol
        if (transform.position == PlayerTargetPosition)
        {
            state = states.patrol;
            
        }

    }
}

