using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int collectedCoins;
    
    public bool moving;

    public float distance;
    
    public TextMeshProUGUI CoinsText;
    public TextMeshProUGUI distanceText; 
    // Start is called before the first frame update
    private void Awake()
    {
        collectedCoins = 0; 
    }

    private void Start()
    {
        moving = true;
        distance = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            distance += Time.deltaTime;
            distanceText.text = distance.ToString("0") + " : Distance";
        }
    }

    public void AddCoin()
    {
        collectedCoins++;
        CoinsText.text = collectedCoins.ToString("0") + " : Coins";
    }
}
