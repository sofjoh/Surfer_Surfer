using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SharkController : MonoBehaviour
{
    [Tooltip("Speed of shark when activated.")]
    public float SharkSpeed = 0.1f;
    [Tooltip("Player GameObject")]
    public GameObject Player;
    [Tooltip("The node for where the player should start")]
    public Transform SharkNode;
    private float originalSpeed;
    [HideInInspector] public bool sharkGo; 
    [HideInInspector] public bool sharkGoBack;
    private GameObject gameController;
    private SceneHandler sceneHandler;

    void Start()
    {
        gameController = FindObjectOfType<SceneHandler>().gameObject;
        sceneHandler = gameController.GetComponent<SceneHandler>();
    }

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
            Debug.Log("dead");
            sceneHandler.Dead = true;
        }
    }

    public void StartTheShark()
    {
        transform.position = Vector3.Lerp(transform.position, Player.transform.position, SharkSpeed * Time.deltaTime);
    }    
    
    public void StopTheShark()
    {
        transform.position = Vector3.Lerp(transform.position, SharkNode.position, SharkSpeed * Time.deltaTime);
    }

    private void OnValidate()
    {
        if (SharkSpeed <= 0)
        {
            Debug.LogWarning("shark speed should be a positive value");
        }
    }

    public void SetSharkTOrigin()
    {
        transform.position = SharkNode.position;
        sharkGo = false;
    }
}
