using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
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
    public TextMeshProUGUI HighscoreDistance;
    public TextMeshProUGUI HighscoreCoins;
    private LevelGenerator lvlgen;

    private void Start()
    {
        lvlgen = LevelGenerator.lvlGen;
    }

    // Update is called once per frame
    void Update()
    {

        if (Dead)
        {
            lvlgen.ObstacleSpeed = 0;
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

        var highscoreCoins = GetComponent<Stats>().HighscoreCoins;
        HighscoreCoins.text = "Highscore Coins: " + highscoreCoins.ToString("0");
        
        var highscoreDistance = GetComponent<Stats>().HighscoreDistance;
        HighscoreDistance.text = "Highscore Distance: " + highscoreDistance.ToString("0");

        //kanske coorutine här för att visa dead-animation först. Eller sätta en pausgame true när animationen har körts. 
        Time.timeScale = 1; 
    }

    public void restartGame()
    {
        Dead = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void GoToStartMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

}
