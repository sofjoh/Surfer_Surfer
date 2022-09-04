using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlatform : MonoBehaviour
{
    private GameObject levelGenerator;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        levelGenerator = GameObject.Find("LevelGenerator");
    }

    // Update is called once per frame
    void Update()
    {
        speed = levelGenerator.GetComponent<LevelGenerator>().ObstacleSpeed;
        // Debug.Log(speed); Är 20 hela tiden. Ändras inte. 
        transform.Translate(Vector3.forward * -speed * Time.deltaTime);
        
        if (transform.position.z < -60)
        {
            levelGenerator.GetComponent<LevelGenerator>().generateTile();
            Destroy(gameObject);
        }
    }
}
