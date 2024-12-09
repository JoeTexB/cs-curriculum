using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    GameManager gm;
    private float cooldown = 0.7f;
    public PlayerController pl;
    
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        pl = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spikes")) 
        {
            if (pl.phase == false)
            { 
                takedmg();
            }
              
        }    
        if (other.CompareTag("Bullet")) 
        {
            takedmg();
        } 

    }

public void takedmg()
{
    if (cooldown < 0)
    {
        print("take dmg");
        gm.health = gm.health - 1;
        print("you health is: " + gm.health);
        cooldown = 0.7f;
    }
}
    
// Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
    }
}

