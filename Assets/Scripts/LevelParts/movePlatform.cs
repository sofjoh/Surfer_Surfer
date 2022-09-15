using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlatform : MonoBehaviour
{
    private LevelGenerator levelGenerator;
    private float speed;
    
    // Start is called before the first frame update
    void Awake()
    {
        levelGenerator = LevelGenerator.lvlGen;
    }

    // Update is called once per frame
    void Update()
    {
        speed = levelGenerator.ObstacleSpeed;
        transform.Translate(Vector3.forward * -speed * Time.deltaTime);
        
        if (transform.position.z < -60)
        {
            levelGenerator.generateTile();
            Destroy(gameObject);
        }

    }
}
