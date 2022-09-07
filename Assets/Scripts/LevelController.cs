using UnityEngine;

public class LevelController : MonoBehaviour
{
    //private float speed;
    private float NewSpeed;

    private GameObject levelGenerator;
    private float speedToAdd;
    private float OriginalTimer;
    private float timer; 
    private float speed;
    
    // Start is called before the first frame update
    void Awake()
    {
        levelGenerator = FindObjectOfType<LevelGenerator>().gameObject;
        speedToAdd = levelGenerator.GetComponent<LevelGenerator>().SpeedToAdd;
        OriginalTimer = levelGenerator.GetComponent<LevelGenerator>().TimerForSpeedingUp;
        timer = OriginalTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            SpeedUp();
        }
        
        speed = levelGenerator.GetComponent<LevelGenerator>().ObstacleSpeed;
    }

    public void SpeedUp()
    {
        NewSpeed = speed + speedToAdd;
        levelGenerator.GetComponent<LevelGenerator>().ObstacleSpeed = NewSpeed;
        timer = OriginalTimer; 
    }
    
}
