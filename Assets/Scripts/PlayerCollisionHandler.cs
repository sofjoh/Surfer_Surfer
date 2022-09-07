using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerCollisionHandler : MonoBehaviour
{
    [FormerlySerializedAs("nuvarandeSpeed")] [HideInInspector] public float originalSpeed;
    public float collisionSpeed = 0f;
    
    public GameObject LevelGenerator;
    public GameObject Shark;

    public Transform startPoint;
    
    public Transform ForwardCheck;
    public Transform RightCheck;
    public Transform LeftCheck;

    private RaycastHit hit;

    public LayerMask collisionLayers;

    public float checkRadius = 0.25f;
    public float maxDistance = 1f;
    
    private bool ForwardhitToggle;
    private bool SidehitToggle;
    
    private CharacterMovement.Position prevpos;
    private Transform prevnode;

    
    private void Start()
    {
        originalSpeed = LevelGenerator.GetComponent<LevelGenerator>().ObstacleSpeed;
    }

    private void Update()
    {

    }
    
    private void sharkGoBack()
    {
        Shark.GetComponent<SharkController>().sharkGo = false;
        Shark.GetComponent<SharkController>().sharkGoBack = true;
        LevelGenerator.GetComponent<LevelGenerator>().ObstacleSpeed = originalSpeed;
        ForwardhitToggle = false;
    }
    private void ForwardHit()
    {
        if (!ForwardhitToggle)
        {
            originalSpeed = LevelGenerator.GetComponent<LevelGenerator>().ObstacleSpeed;
        }

        ForwardhitToggle = true;
        LevelGenerator.GetComponent<LevelGenerator>().ObstacleSpeed = collisionSpeed;
        Shark.GetComponent<SharkController>().sharkGo = true;
        Shark.GetComponent<SharkController>().sharkGoBack = false;
    }

    private void BounceBack()
    {
        prevpos = GetComponent<CharacterMovement>().previousPosition;
        prevnode = GetComponent<CharacterMovement>().previousNode;
        
        originalSpeed = LevelGenerator.GetComponent<LevelGenerator>().ObstacleSpeed;
        GetComponent<CharacterMovement>().currentPosition = prevpos;
        GetComponent<CharacterMovement>().currentNode = prevnode;
        GetComponent<CharacterMovement>().MovePlayer();
        SidehitToggle = true;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle Block"))
        {
            float xOffset = Mathf.Abs((transform.position.x - other.transform.position.x));

            if (xOffset > 0.25f)
            {
                BounceBack();
            }
            else
            {
                ForwardHit();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obstacle Block"))
        {
            sharkGoBack();
        }
    }
}
