using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; 
    public int score = 0;
    
    // Start is called before the first frame update
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {

    }
    
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    public void AddCoins(int newCoins)
    {
        PersistentData.Instance.coins += newCoins;
    }
    
    // Method to update the score text displayed in the UI
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
//how to convert score to coins when die
    }
}
