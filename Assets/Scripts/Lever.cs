using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lever : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Animator anim;
    public bool phase;
    public float timer;
    public PlayerController pl;
    public Color PlayerAlpha;
    public Color NewAlpha;
    void Start()
    {
        phase = false;
        anim = GetComponent<Animator>();
        pl = FindObjectOfType<PlayerController>();
        //wip
        NewAlpha =  new Color(0.0f, 0.0f, 0.0f, 0.01f);
        pl.GetComponent<MeshRenderer>().material.color = PlayerAlpha;
        print("PlayerAlpha:" + PlayerAlpha);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            phase = false;
        }
        if (phase)
        {
            //wip
            PlayerAlpha = NewAlpha;
            print("Changed Color" + PlayerAlpha);
            
        }
        if (phase == false)
        {
            
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Touching Lever!");
            anim.SetTrigger("ALever_0");
            phase = true;
            timer = 15;
        }
    }
}   

