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
            //Debug.Log(timer);
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
        //bugg: newSpeed blir hela tiden 70. Den funkar bara första iterationen.
        //Debug.Log(NewSpeed);
        levelGenerator.GetComponent<LevelGenerator>().ObstacleSpeed = NewSpeed;
       // Debug.Log(levelGenerator.GetComponent<LevelGenerator>().ObstacleSpeed);
        //debugg säger att den ändrar speed men den ändrar inte den faktiska speeden.  
        timer = OriginalTimer; 
    }
    
}
