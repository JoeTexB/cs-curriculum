using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private float cooldown;
    private float firerate;
    public GameObject Bullet;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Ontriggerstay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && cooldown < 0 )
        {
            GameObject instance = Instantiate(Bullet, transform position).GetComponent<Bullet>();
            print("Spawn Bullet");
            //Bullet.targetPos = Player.position;
            cooldown = firerate;
        }
    }
    
    
    
    
    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
    }
}
