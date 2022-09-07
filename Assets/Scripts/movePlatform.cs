using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlatform : MonoBehaviour
{
    private GameObject levelGenerator;
    public float speed;
    // Start is called before the first frame update
    void Awake()
    {
        levelGenerator = GameObject.Find("LevelGenerator");
    }

    // Update is called once per frame
    void Update()
    {
        speed = levelGenerator.GetComponent<LevelGenerator>().ObstacleSpeed;
        transform.Translate(Vector3.forward * -speed * Time.deltaTime);
        
        if (transform.position.z < -60)
        {
            levelGenerator.GetComponent<LevelGenerator>().generateTile();
            Destroy(gameObject);
        }
    }
}
