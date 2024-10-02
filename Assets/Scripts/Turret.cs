using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private float cooldown;
    [SerializeField] private float firerate;
    public GameObject Bullet;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Collision?
    private void OnTriggerStay2D(Collider2D other)
    {
        //Is player?
        if (other.gameObject.CompareTag("Player") && cooldown < 0 )
        {
            print("Working");
            //Make clone
            GameObject clone = Instantiate(Bullet, transform.position, Quaternion.identity);
            //Clone the clone script
            Bullet script = clone.GetComponent<Bullet>();
            print("Spawn Bullet");
            //Bullet.targetPos = Player.position;
            cooldown = firerate;
            script.targetPosition = other.transform.position;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        
    }
}
