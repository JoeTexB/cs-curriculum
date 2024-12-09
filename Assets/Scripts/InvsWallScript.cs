using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvsWallScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    public PlayerController pl;
    public SpriteRenderer WallRenderer;
    private void Start()
    {
        pl = FindObjectOfType<PlayerController>();
        GetComponent<BoxCollider2D> ().enabled = true;
        WallRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        print("working");
        if (pl.phase)
        {
            //it's fine
            GetComponent<BoxCollider2D> ().enabled = false;
            
            WallRenderer.color = new Color(1, 1, 1, .1f);
        }
        if (pl.phase == false)
        {
            WallRenderer.color = new Color(1, 1, 1, 1f);
            GetComponent<BoxCollider2D> ().enabled = true;
        }
    }

}
