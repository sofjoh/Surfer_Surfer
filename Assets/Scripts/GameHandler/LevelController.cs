using System;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    //private float speed;
    private float NewSpeed;

    private LevelGenerator lvlGen;
    private float speedToAdd;
    private float OriginalTimer;
    private float timer; 
    private float speed;
    public GameObject Player;
    private PlayerCollisionHandler playcolhand;
    private float highestSpeed;
    
    private void Start()
    {
        lvlGen = LevelGenerator.lvlGen;
        speedToAdd = lvlGen.SpeedToAdd;
        OriginalTimer = lvlGen.TimerForSpeedingUp;
        timer = OriginalTimer;
        playcolhand = Player.GetComponent<PlayerCollisionHandler>();
        highestSpeed = lvlGen.HighestSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0 && !playcolhand.ForwardhitToggle && highestSpeed > lvlGen.ObstacleSpeed)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0 && !playcolhand.ForwardhitToggle && highestSpeed > lvlGen.ObstacleSpeed)
        {
            SpeedUp();
        }
        
        speed = lvlGen.ObstacleSpeed;
    }

    public void SpeedUp()
    {
        NewSpeed = speed + speedToAdd;
        lvlGen.ObstacleSpeed = NewSpeed;
        timer = OriginalTimer; 
    }
    
}
