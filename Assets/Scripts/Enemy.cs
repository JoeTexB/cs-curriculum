using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public List <Vector3> waypoints;
    private int state = 1;
    private int num;
    
    public Vector3 PlayerTargetPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            state = 2;
            
            PlayerTargetPosition = other.transform.position;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if (state == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[num], 2 * Time.deltaTime);
        }

        if (transform.position == waypoints[num])
        {
            num += 1;
            if (num > 6)
            {
                num = 0;
            }
        }

        if (state == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, PlayerTargetPosition, 2 * Time.deltaTime);
            
        }

        if (transform.position == PlayerTargetPosition)
        {
            state = 1;
        }

    }
}

