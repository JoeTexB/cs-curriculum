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
            gm.Health = gm.Health - 1;
            print("you health is: "+gm.Health);
            




        }    

    }

    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
