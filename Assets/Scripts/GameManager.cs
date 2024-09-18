using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Coins = 0;
    public GameManager gm;

    private void Awake()
    {
        if(gm!=null & gm!= this)
       {
            //imposter found
            Destroy(gameObject);
        }
        else
        {
            //original
            gm = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
