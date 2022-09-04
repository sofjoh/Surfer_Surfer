using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public bool Dead;

    public GameObject InGameScreen;

    public GameObject GameOverScreen;

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
        
        //PAUSE GAME
    }
}
