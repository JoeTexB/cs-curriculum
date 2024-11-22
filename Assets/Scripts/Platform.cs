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
    public int PlatformPositive;
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
        if (PlatformXDifference.x < 0)
        {
            PlatformPositive = -1;
        }

        if (PlatformXDifference.x > 0)
        {
            PlatformPositive = 1;
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pl.transform.position.Set(transform.position.x, pl.transform.position.y, pl.transform.position.z);
        }
    } 
}
    