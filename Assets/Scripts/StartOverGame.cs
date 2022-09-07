using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartOverGame : MonoBehaviour
{
    public Button PlayAgain;

    //distance in stats-script
    //coins collectedCoins in stats-script
    
    //set back speed of level
    //set back the shark
    //delete the level parts
    //regenerate level
    //deactivate game over screen
    //activate In game screen

    public void restartGame()
    {
        GetComponent<GameOver>().Dead = false;
        Time.timeScale = 1; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
