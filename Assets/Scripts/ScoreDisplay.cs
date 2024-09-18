using UnityEngine;
using TMPro;
public class ScoreDisplay : MonoBehaviour
{
    GameManager gm;

    public TextMeshProUGUI scoreText;

    private void Start()
    {

        gm = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        //working on: scoreText.text = gm.Coins;
        // Your code here: Update the scoreText with the current score
        // Hint: use scoreText.text to access the string component of text
        
    // Hint: Use gm.GetScore();
}
}

