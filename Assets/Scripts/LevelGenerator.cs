using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] LevelParts;

    [Tooltip("Should be the same as the level parts length in z")]
    public float Offset = 40f; 
    private Transform spawningPosition;
    public Transform StartTile;
    private int numberOfTiles;

    public float ObstacleSpeed = 20f; 
    // Start is called before the first frame update
    void Start()
    {
        numberOfTiles = LevelParts.Length;
        GenerateStartLevel();
    }

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

}
