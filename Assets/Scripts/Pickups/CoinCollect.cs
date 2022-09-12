using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    private GameObject GameHandler; 

    void Start()
    {
        GameHandler = FindObjectOfType<Stats>().gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameHandler.GetComponent<Stats>().AddCoin();
        Destroy(gameObject);
    }
}
