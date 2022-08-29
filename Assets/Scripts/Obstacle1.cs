using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle1 : MonoBehaviour
{
    public float timer = 30f;
    public float collisionSpeed = 0f; 
    public GameObject levelGenerator;
    public GameObject Shark;
    public bool Dead;

    private void OnTriggerEnter(Collider other)
    {
        levelGenerator.GetComponent<LevelGenerator>().ObstacleSpeed = 0;
        StartTimer();
        Shark.GetComponent<SharkController>().sharkGo = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Shark.GetComponent<SharkController>().sharkGo = false;
    }

    private void StartTimer()
    {
        while (timer > 0f)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            Dead = true; 
        }
    }
}
