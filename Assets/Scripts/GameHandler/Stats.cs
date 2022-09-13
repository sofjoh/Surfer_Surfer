using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [HideInInspector] public int collectedCoins;
   
    [HideInInspector] public float distance;

     public float HighscoreDistance;
     public int HighscoreCoins;

    [Tooltip("Text for coin count")]
    public TextMeshProUGUI CoinsText;
    [Tooltip("Text for distance count")]
    public TextMeshProUGUI distanceText;

    public GameObject GameHandler;
    private SceneHandler sceneHandl;

    private void Start()
    {
        collectedCoins = 0; 
        distance = 0;
        sceneHandl = GameHandler.GetComponent<SceneHandler>();
        CoinsText.text = collectedCoins.ToString("0") + " : Coins";
        HighscoreDistance = PlayerPrefs.GetFloat("HighscoreDistance");
        HighscoreCoins = PlayerPrefs.GetInt("HighscoreCoins");
    }

    // Update is called once per frame
    void Update()
    {
        if (!sceneHandl.Dead && !GameHandler.GetComponent<Countdown>().countdown)
        {
            distance += Time.deltaTime;

            if (distance > PlayerPrefs.GetFloat("HighscoreDistance"))
            {
                HighscoreDistance = distance;
                PlayerPrefs.SetFloat("HighscoreDistance", HighscoreDistance);
                PlayerPrefs.Save();
            }
        }
        distanceText.text = distance.ToString("0") + " : Distance";
    }
    
    public void AddCoin()
    {
        collectedCoins++;
        CoinsText.text = collectedCoins.ToString("0") + " : Coins";

        if (collectedCoins > PlayerPrefs.GetInt("HighscoreCoins"))
        {
            HighscoreCoins = collectedCoins;
            PlayerPrefs.SetInt("HighscoreCoins", HighscoreCoins);
            PlayerPrefs.Save();
        }
    }
    
}
