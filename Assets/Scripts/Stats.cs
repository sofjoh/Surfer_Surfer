using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int collectedCoins;
    
    public TextMeshProUGUI CoinsText;
    // Start is called before the first frame update
    private void Awake()
    {
        collectedCoins = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoin()
    {
        collectedCoins++;
        CoinsText.text = collectedCoins.ToString("0") + " : Coins";
    }
}
