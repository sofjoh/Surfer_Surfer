using UnityEngine;

public class LevelController : MonoBehaviour
{
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = GameObject.Find("LevelGenerator").GetComponent<LevelGenerator>().ObstacleSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * -speed * Time.deltaTime);

        if (transform.position.z < -50)
        {
            GameObject.Find("LevelGenerator").GetComponent<LevelGenerator>().generateTile();
            Destroy(gameObject);
        }
    }
    
}
