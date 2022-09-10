using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [HideInInspector] public int collectedCoins;
    
    //public bool moving;

    //private float originalSpeed;
    [HideInInspector] public float distance;

    //public GameObject levelGenerator;
    [Tooltip("Text for coin count")]
    public TextMeshProUGUI CoinsText;
    [Tooltip("Text for distance count")]
    public TextMeshProUGUI distanceText; 
    //public TextMeshProUGUI CountDownText;
    //private bool countdown;
    //public GameObject countDown;

    //public float CountDownTimer = 5;
    // Start is called before the first frame update
    private void Awake()
    {
        collectedCoins = 0; 
    }

    private void Start()
    {
        //originalSpeed = levelGenerator.GetComponent<LevelGenerator>().ObstacleSpeed;
        //levelGenerator.GetComponent<LevelGenerator>().ObstacleSpeed = 0;
        //moving = false;
        distance = 0;
       // countdown = true;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (countdown)
        {
            CountDownTimer -= Time.deltaTime;
            CountDownText.text =  CountDownTimer.ToString("0");
        }

        if (CountDownTimer < 0)
        {
            if (countDown)
            {
                levelGenerator.GetComponent<LevelGenerator>().ObstacleSpeed = originalSpeed;
                countdown = false;
                moving = true;
                countDown.SetActive(false);
                countDownToggle = false;
            }

        }*/
        //if (moving)
        //{
            distance += Time.deltaTime;
            distanceText.text = distance.ToString("0") + " : Distance";
       // }
    }
    
    public void AddCoin()
    {
        collectedCoins++;
        CoinsText.text = collectedCoins.ToString("0") + " : Coins";
    }
    
}
