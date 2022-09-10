using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [HideInInspector] public bool Dead;
    
    [Tooltip("Game object with the in Game UI")]
    public GameObject InGameScreen;
    [Tooltip("Game object with game over UI")]
    public GameObject GameOverScreen;
    [Tooltip("The text for resulting distance (game over canvas)")]
    public TextMeshProUGUI ResultDistance;
    [Tooltip("The text for resulting coin count (game over canvas)")]
    public TextMeshProUGUI ResultCoins;
   // public TextMeshProUGUI Highscore;

    // Update is called once per frame
    void Update()
    {

        if (Dead)
        {
            GameIsOver();
        }
        
    }

    public void GameIsOver()
    {
        InGameScreen.SetActive(false);
        GameOverScreen.SetActive(true);

        var resultCoins = GetComponent<Stats>().collectedCoins;
         ResultCoins.text = "Coins: " + resultCoins.ToString("0");

         var resultDistance = GetComponent<Stats>().distance;
         ResultDistance.text = "Distance: " + resultDistance.ToString("0");

         //kanske coorutine här för att visa dead-animation först. Eller sätta en pausgame true när animationen har körts. 
         Time.timeScale = 0; 
    }
}
