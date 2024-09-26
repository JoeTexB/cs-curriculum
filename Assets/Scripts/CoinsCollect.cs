using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsCollect : MonoBehaviour
{
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Coin"))
        {
            gm.coins = gm.coins + 1;
            print("I have " + gm.coins + " Coins!");
            Destroy(other.gameObject);

        }

    }
}