using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    //stop distance from counting
    
    private LevelGenerator lvlGen;
    [Tooltip("Value for countdown timer before game starts.")]
    public float Timer = 5;
    public bool countdown = true;
    private float speed;
    public TextMeshProUGUI countdownText;
    private bool scriptActive;


    private void Start()
    {
        lvlGen = LevelGenerator.lvlGen;
        speed = lvlGen.ObstacleSpeed;
        countdown = true;
        scriptActive = true;
    }

    private void Update()
    {
        if (countdown && scriptActive)
        {
            startTimer();
        }

        if (!countdown && scriptActive)
        {
            startGame();
        }
    }


    public void startTimer()
    {
        lvlGen.ObstacleSpeed = 0;
        Timer -= Time.deltaTime;
        countdownText.text = Timer.ToString("0");
        //distance don't count

        if (Timer < 0)
        {
            countdown = false;
        }
    }

    public void startGame()
    {
        scriptActive = false;
        lvlGen.ObstacleSpeed = speed;
        countdownText.gameObject.SetActive(false);
    }

}
