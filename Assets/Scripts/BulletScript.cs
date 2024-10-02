using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    private int Speed = 10;

    public Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        //max distance can travel
        Vector3.MoveTowards(transform.position, targetPosition, 10 * Time.deltaTime);  
    }

    // Update is called once per frame
    void Update()
    {
      //move towards player  
      transform.position = Vector3.MoveTowards(transform.position, targetPosition, 5 * Time.deltaTime);
    }
}
