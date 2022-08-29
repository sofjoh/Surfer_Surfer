using UnityEngine;

public class LevelController : MonoBehaviour
{
    private float speed;

    private GameObject levelGenerator;
    
    // Start is called before the first frame update
    void Start()
    {
        levelGenerator = GameObject.Find("LevelGenerator");
    }

    // Update is called once per frame
    void Update()
    {
        speed = levelGenerator.GetComponent<LevelGenerator>().ObstacleSpeed;
        transform.Translate(Vector3.forward * -speed * Time.deltaTime);

        if (transform.position.z < -50)
        {
            GameObject.Find("LevelGenerator").GetComponent<LevelGenerator>().generateTile();
            Destroy(gameObject);
        }
    }
    
}
