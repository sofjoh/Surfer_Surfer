using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [HideInInspector] public float nuvarandeSpeed;
    public float collisionSpeed = 0f;
    
    public GameObject LevelGenerator;
    public GameObject Shark;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        var prevpos = GetComponent<CharacterMovement>().previousPosition;
        var prevnode = GetComponent<CharacterMovement>().previousNode;
        if (other.CompareTag("Obstacle Block"))
        {
            var dir = Vector3.Normalize(transform.position - other.transform.position);
            var dot = Vector3.Dot(other.transform.forward * -1, new Vector3(0, 0, dir.z));
            if (dot > 0.707f)
            {
                nuvarandeSpeed = LevelGenerator.GetComponent<LevelGenerator>().ObstacleSpeed;
                LevelGenerator.GetComponent<LevelGenerator>().ObstacleSpeed = collisionSpeed;
                Shark.GetComponent<SharkController>().sharkGo = true;
                Shark.GetComponent<SharkController>().sharkGoBack = false;
            }
            else
            {
                nuvarandeSpeed = LevelGenerator.GetComponent<LevelGenerator>().ObstacleSpeed;
                GetComponent<CharacterMovement>().currentPosition = prevpos;
                GetComponent<CharacterMovement>().currentNode = prevnode;
                GetComponent<CharacterMovement>().MovePlayer();
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obstacle Block"))
        {
            Shark.GetComponent<SharkController>().sharkGo = false;
            Shark.GetComponent<SharkController>().sharkGoBack = true;
            LevelGenerator.GetComponent<LevelGenerator>().ObstacleSpeed = nuvarandeSpeed;
        }
    }
}
