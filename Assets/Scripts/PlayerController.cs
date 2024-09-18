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

    

    public bool overworld;
    Rigidbody2D rb;

    private void Start()
    {

        gm = FindObjectOfType<GameManager>();

        xspeed = 4f;
        xdirection = 0;
        xvector = 0;

        

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
        
        if (other.CompareTag("Coin")) 
        {
            gm.Coins = gm.Coins + 1;
            print("I have " + gm.Coins + " Coins!");
            Destroy(other.gameObject);




        }
    }

    //after all Unity functions, your own functions can go here

}