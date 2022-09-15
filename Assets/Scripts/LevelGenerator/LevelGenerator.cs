using System;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator lvlGen;
    public GameObject[] LevelParts;

    [Tooltip("Should be the same as the level parts length in z")]
    public float Offset = 40f; 
    //private Transform spawningPosition;
    
    [Tooltip("The first tile in the level.")]
    public Transform StartTile;
    private int numberOfTiles;
    private int tilesTogenerate = 4;

    [Tooltip("The start speed of the level.")]
    public float ObstacleSpeed = 20f;
    [Tooltip("How many seconds should pass before the obstacles move faster?")]
    public float TimerForSpeedingUp = 20f;
    [Tooltip("How much do you want to increase the speed each time the timer hits 0?")]
    public float SpeedToAdd = 1f;
    [Tooltip("Highest speed the level can reach.")]
    public float HighestSpeed = 50;
    // Start is called before the first frame update
    private void Awake()
    {
        lvlGen = this;
    }

    void Start()
    {
        numberOfTiles = LevelParts.Length;
        GenerateStartTile();
        GenerateStartLevel();
    }
    private void OnValidate()
    {
        if (Offset < 0)
        {
            Debug.LogError("Value of offset is negative. It should be a positive value and the same as the level parts length in z.");
        }

        if (ObstacleSpeed <= 0)
        {
            Debug.LogWarning("Obstacle speed should be a positive value");
        }
        
        if (TimerForSpeedingUp <= 0)
        {
            Debug.LogWarning("Timer for speeding up should be a positive value");
        }
    }
    
/// <summary>
/// Randomize en levelbit och initierar den längst bak i banan. 
/// </summary>
    public void generateTile()
    {
        var index = Random.Range(0, numberOfTiles);
            Instantiate(LevelParts[index], new Vector3(0, 0, tilesTogenerate*Offset), transform.rotation);
    }

    public void GenerateStartLevel()
    {
        for (int i = 0; i < tilesTogenerate; i++)
        {
            var index = Random.Range(0, numberOfTiles);
            Instantiate(LevelParts[index], new Vector3(0, 0, Offset * (i+1)), transform.rotation);
        }
    }

    public void GenerateStartTile()
    {
        Instantiate(StartTile, new Vector3(0, 0, 0), transform.rotation);
    }

}
