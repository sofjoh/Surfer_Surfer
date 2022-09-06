using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle1 : MonoBehaviour
{
    public float collisionSpeed = 0f;
    public float nuvarandeSpeed; 
    private GameObject levelGenerator;
    public GameObject Shark;

    private void Awake()
    {
        GetComponent<Collider>().isTrigger = true;
        levelGenerator = FindObjectOfType<LevelGenerator>().gameObject;
        Shark = FindObjectOfType<SharkController>().gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            nuvarandeSpeed = levelGenerator.GetComponent<LevelGenerator>().ObstacleSpeed;
            levelGenerator.GetComponent<LevelGenerator>().ObstacleSpeed = collisionSpeed;
            Shark.GetComponent<SharkController>().sharkGo = true;
            Shark.GetComponent<SharkController>().sharkGoBack = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Shark.GetComponent<SharkController>().sharkGo = false;
            Shark.GetComponent<SharkController>().sharkGoBack = true;
            levelGenerator.GetComponent<LevelGenerator>().ObstacleSpeed = nuvarandeSpeed;
        }
    }
}
