using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;







public class PlayerController : MonoBehaviour
{
    float xspeed;
    float xdirection;
    float xvector;

    float yspeed;
    float ydirection;
    float yvector;

    int coins;

    public bool overworld;
    Rigidbody2D rb;

    private void Start()
    {
        xspeed = 4f;
        xdirection = 0;
        xvector = 0;

        coins = 0;

        yspeed = 4f;
        ydirection = 0;
        yvector = 0;

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

       
    }

    //for organization, put other built-in Unity functions here

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("coin")) ; //shouldn't work?????
        {
            coins = coins + 1;
            print("I have " + coins + " Coins!");
            Destroy(other.gameObject);


        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("collision"))
        {

        }


    }




    //after all Unity functions, your own functions can go here

}