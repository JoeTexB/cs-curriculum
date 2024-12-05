using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Platform : MonoBehaviour
{
    public bool Moving;
    public List <Vector3> waypoints;
    private int num;
    PlayerController pl;
    public Vector3 PlatformXDifference;
    public int platformDirection;
    public Vector3 platformposoffset;
    
    // Start is called before the first frame update
    void Start()
    {
        Moving = true;
        pl = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
        if (Moving == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[num], 3 * Time.deltaTime);
        }
    
        if (transform.position == waypoints[num])
        {
            num += 1;
            if (num > 1)
            {
                num = 0;
            }
        }
        
        //all wip below
        PlatformXDifference.Set(waypoints[0].x - waypoints[1].x, 0, 0);
        PlatformXDifference.Set(transform.position.x - waypoints[num].x , 0, 0);
        if (PlatformXDifference.x < 0)
        {
            
            platformDirection = 1;
            //print("Platform positive" + platformDirection);
        }

        if (PlatformXDifference.x > 0)
        {
            
            platformDirection = -1;
            //print("Platform negative" + platformDirection);
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            
            float movement = 0.055f * platformDirection;
            pl.transform.Translate(movement, 0, 0);
            //print(movement);
        }
    } 
}
    