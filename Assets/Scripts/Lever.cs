using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lever : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Animator anim;
    public PlayerController pl;
    void Start()
    {
        anim = GetComponent<Animator>();
        pl = FindObjectOfType<PlayerController>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Touching Lever!");
            anim.SetTrigger("ALever_0");
            pl.phase = true;
            pl.phaseTimer = 10;
        }
    }
}   

