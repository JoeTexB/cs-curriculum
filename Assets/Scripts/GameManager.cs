using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public int coins = 0;
    public int health = 10;
    public static GameManager gm;


    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI CoinsText;

    private void Awake()
    {
        Debug.Log("Hello World!");
        if (gm != null && gm != this)
        {
            Debug.Log("found Imposter" + gm);
            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("Im the original gm!");
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

        CoinsText.text = "Coins: " + coins;
        HealthText.text = "Health: " + health;

        if (health < 1) 
        {
            print("You died");
            Die();
            
        }
    }


    void Die()
    {
        SceneManager.LoadScene(0);
        health = 10;
        coins = 0;

    }


}
