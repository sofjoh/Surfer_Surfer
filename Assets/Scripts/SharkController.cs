using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SharkController : MonoBehaviour
{
    public float SharkSpeed = 0.1f;

    public GameObject LevelGenerator; 
    public GameObject Player; 
    public GameObject SharkNode;
    private float originalSpeed;
    public bool sharkGo; 
    public bool sharkGoBack;
    private GameObject gameController;
    public Vector3 startPosition; 

    // Start is called before the first frame update
    void Start()
    {
        originalSpeed = LevelGenerator.GetComponent<LevelGenerator>().ObstacleSpeed;
        gameController = FindObjectOfType<GameOver>().gameObject;
        startPosition = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        if (sharkGo)
        {
            StartTheShark();
        }
        if(sharkGoBack)
        {
            StopTheShark();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameController.GetComponent<GameOver>().Dead = true;
        }
    }


    public void StartTheShark()
    {
        transform.position = Vector3.Lerp(transform.position, Player.transform.position, SharkSpeed * Time.deltaTime);
        //transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, SharkSpeed * Time.deltaTime);
    }    
    
    public void StopTheShark()
    {
        transform.position = Vector3.Lerp(transform.position, SharkNode.transform.position, SharkSpeed * Time.deltaTime);
        //transform.position = Vector3.MoveTowards(transform.position, SharkNode.transform.position, SharkSpeed * Time.deltaTime);
    }
}
