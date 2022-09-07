using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public bool Dead;

    public GameObject InGameScreen;

    public GameObject GameOverScreen;
    
    public TextMeshProUGUI ResultDistance;
    public TextMeshProUGUI ResultCoins;
    public TextMeshProUGUI Highscore;

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
