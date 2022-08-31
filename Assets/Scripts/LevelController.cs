using UnityEngine;

public class LevelController : MonoBehaviour
{
    private float speed;
    private float NewSpeed;

    private GameObject levelGenerator;
    private float speedToAdd;
    private float OriginalTimer;
    private float timer; 
    
    // Start is called before the first frame update
    void Start()
    {
        levelGenerator = GameObject.Find("LevelGenerator");
        speedToAdd = levelGenerator.GetComponent<LevelGenerator>().SpeedToAdd;
        OriginalTimer = levelGenerator.GetComponent<LevelGenerator>().TimerForSpeedingUp;
        timer = OriginalTimer; 
    }

    // Update is called once per frame
    void Update()
    {
        speed = levelGenerator.GetComponent<LevelGenerator>().ObstacleSpeed;
        
        while (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            SpeedUp();
        }
        
        transform.Translate(Vector3.forward * -speed * Time.deltaTime);

        if (transform.position.z < -50)
        {
            GameObject.Find("LevelGenerator").GetComponent<LevelGenerator>().generateTile();
            Destroy(gameObject);
        }
    }

    public void SpeedUp()
    {
        NewSpeed = speed + speedToAdd;
        levelGenerator.GetComponent<LevelGenerator>().ObstacleSpeed = NewSpeed;
        timer = OriginalTimer; 
    }
    
}
