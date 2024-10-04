using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    GameManager gm;
    
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spikes")) 
        {
            print("Touched Spike");
            gm.health = gm.health - 1;
            print("you health is: "+gm.health);
            
            




        }    
        if (other.CompareTag("Bullet")) 
        {
            print("Bullet Hit Player");
            gm.health = gm.health - 1;
            print("you health is: "+gm.health);
            Destroy(other.gameObject);





        } 

    }

    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        
    }
}

