using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    private GameObject GameHandler; 
    // Start is called before the first frame update
    void Start()
    {
        GameHandler = FindObjectOfType<Stats>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        GameHandler.GetComponent<Stats>().AddCoin();
        Destroy(gameObject);
    }
}
