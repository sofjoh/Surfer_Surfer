using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle1 : MonoBehaviour
{
    //public float collisionSpeed = 0f;
   // public float nuvarandeSpeed; 
    //private GameObject levelGenerator;
    //public GameObject Shark;

    private void Awake()
    {
        GetComponent<Collider>().isTrigger = true;
        gameObject.tag = "Obstacle Block"; 
        //levelGenerator = FindObjectOfType<LevelGenerator>().gameObject;
        //Shark = FindObjectOfType<SharkController>().gameObject;
    }
}