using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnScript : MonoBehaviour
{
    public GameObject[] obstacles; // Array to hold different obstacle prefabs
    [SerializeField] private GameObject scorePlane;
    public float spawnRate;
    private float spawnRateDecrement = 0.1f;
    // private float spawnRateMin = 2.0f;
    public float speed;
    private float speedIncrement = 1f;
    // private float speedMax = 20.0f;
    private float increaseRate = 10.0f;
    private float increaseTimer = 0;
    private float spawnTimer = 0;
    public int highest = 3;
    public PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("PlayerMove").GetComponent<PlayerMovement>();
        spawnRate = 2.0f;
        speed = 10.0f;
        spawnObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerMovement.isAlive)
            return;
        if (spawnTimer < spawnRate)
        {
            Debug.Log("Waiting to spawn " + spawnTimer);
            spawnTimer = spawnTimer + Time.deltaTime;
        }
        else
        {
            Debug.Log(spawnTimer);
            Debug.Log(spawnRate);
            spawnObstacle();
            spawnTimer = 0;
        }

        if (increaseTimer < increaseRate)
        {
            increaseTimer = increaseTimer + Time.deltaTime;
        }
        else
        {
            Debug.Log("Increasing difficulty");
            spawnRate = spawnRate - spawnRateDecrement;
            speed = speed + speedIncrement;
            increaseTimer = 0;
        }
    }

    void spawnObstacle()
    {
        int randomIndex = Random.Range(0, obstacles.Length); // Get a random index for the obstacles array
        GameObject selectedObstacle = obstacles[randomIndex]; // Select a random obstacle

        if (randomIndex == 2) {
            int randomY = Random.Range(1, highest);
            GameObject obstacle = Instantiate(selectedObstacle, new Vector3(transform.position.x, transform.position.y + randomY + 0.75f, transform.position.z), transform.rotation);
            ObstacleMoveScriptBird obstacleMoveScriptBird = obstacle.GetComponent<ObstacleMoveScriptBird>();
            obstacleMoveScriptBird.speed = speed;
        } else {
            int random = Random.Range(-1, 3);
            for (int i = -1; i < 2; i++) {
                if (random == i) {
                    continue;
                }
                GameObject obstacle = Instantiate(selectedObstacle, new Vector3(transform.position.x + i * playerMovement.leftRightLimit, transform.position.y, transform.position.z), transform.rotation);
                ObstacleMoveScript obstacleMoveScript = obstacle.GetComponent<ObstacleMoveScript>();
                obstacleMoveScript.speed = speed;
            }
        }


        GameObject score = Instantiate(scorePlane, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
        ObstacleMoveScriptPlane obstacleMoveScriptPlane = score.GetComponent<ObstacleMoveScriptPlane>();
        obstacleMoveScriptPlane.speed = speed;
    }
}
