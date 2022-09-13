using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerCollisionHandler : MonoBehaviour
{
    [FormerlySerializedAs("nuvarandeSpeed")] [HideInInspector] public float originalSpeed;
    [HideInInspector]public float collisionSpeed = 0f;
    
    public GameObject LevelGenerator;
    public GameObject Shark;

    //private RaycastHit hit;

    public bool ForwardhitToggle;
    private bool SidehitToggle;
    
    private CharacterMovement.Position prevpos;
    private Transform prevnode;

    private GameObject currentHit;
    private SharkController sharkController;

    public GameObject gameHandler;
    private SceneHandler SceneHandler;

    private CameraShake screenShake;

    private void Start()
    {
        originalSpeed = LevelGenerator.GetComponent<LevelGenerator>().ObstacleSpeed;
        sharkController = Shark.GetComponent<SharkController>();
        SceneHandler = gameHandler.GetComponent<SceneHandler>();
        if (Camera.main != null)
        {
            screenShake = Camera.main.GetComponent<CameraShake>();
        }
    }

    private void sharkGoBack()
    {
        //om inte död 
        sharkController.sharkGo = false;
        sharkController.sharkGoBack = true;
        LevelGenerator.GetComponent<LevelGenerator>().ObstacleSpeed = originalSpeed;
        ForwardhitToggle = false;
    }
    private void ForwardHit()
    {
        if (!ForwardhitToggle)
        {
            originalSpeed = LevelGenerator.GetComponent<LevelGenerator>().ObstacleSpeed;
            screenShake.screenShake(20, 0.1f);
        }

        ForwardhitToggle = true;
        LevelGenerator.GetComponent<LevelGenerator>().ObstacleSpeed = collisionSpeed;
        sharkController.sharkGo = true;
        sharkController.sharkGoBack = false;
    }

    private void BounceBack()
    {
        screenShake.screenShake(10, 0.1f);
        prevpos = GetComponent<CharacterMovement>().previousPosition;
        prevnode = GetComponent<CharacterMovement>().previousNode;
        
        GetComponent<CharacterMovement>().currentPosition = prevpos;
        GetComponent<CharacterMovement>().currentNode = prevnode;
        GetComponent<CharacterMovement>().MovePlayer();
        SidehitToggle = true;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("front bump") && (!currentHit || other.gameObject != currentHit))
        {
            ForwardHit();
            currentHit = other.gameObject;
        }

        if (other.CompareTag("side bump"))
        {
            BounceBack();
        }

        if (other.CompareTag("death bump"))
        {
            SceneHandler.Dead = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obstacle Block") || other.CompareTag("front bump"))
        {
            sharkGoBack();
        }
    }
}
