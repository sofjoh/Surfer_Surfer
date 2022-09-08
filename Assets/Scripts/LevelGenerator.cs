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
    private Transform spawningPosition;
    public Transform StartTile;
    private int numberOfTiles;

    public float ObstacleSpeed = 20f;
    [Tooltip("How many seconds should pass before the obstacles move faster?")]
    public float TimerForSpeedingUp = 20f;
    [Tooltip("How much do you want to increase the speed?")]
    public float SpeedToAdd = 1f; 
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
        if (Offset < 40)
        {
            Debug.LogError("Fix value of offset");
        }
    }
/// <summary>
/// Randomize en levelbit och initierar den längst bak i banan. 
/// </summary>
    public void generateTile()
    {
        var index = Random.Range(0, numberOfTiles);
            Instantiate(LevelParts[index], new Vector3(0, 0, numberOfTiles*Offset), transform.rotation);
    }

    public void GenerateStartLevel()
    {
        for (int i = 0; i < numberOfTiles; i++)
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
