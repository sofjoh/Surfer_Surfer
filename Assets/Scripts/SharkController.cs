using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkController : MonoBehaviour
{
    public float SharkSpeed = 0.1f;

    public GameObject LevelGenerator; 
    public GameObject Player; 
    public GameObject SharkNode;
    private float originalSpeed;
    public bool sharkGo; 
    public bool sharkGoBack; 
    
    // Start is called before the first frame update
    void Start()
    {
        originalSpeed = LevelGenerator.GetComponent<LevelGenerator>().ObstacleSpeed; 
    }

    // Update is called once per frame
    void Update()
    {
        if (sharkGo)
        {
            StartTheShark();
        }
        else
        {
            StopTheShark();
        }
    }


    public void StartTheShark()
    {
        Debug.Log("Shark started");
        transform.position = Vector3.Lerp(transform.position, Player.transform.position, SharkSpeed * Time.deltaTime);
    }    
    
    public void StopTheShark()
    {
        transform.position = Vector3.Lerp(transform.position, SharkNode.transform.position, SharkSpeed * Time.deltaTime);
        LevelGenerator.GetComponent<LevelGenerator>().ObstacleSpeed = originalSpeed; 
    }
}
