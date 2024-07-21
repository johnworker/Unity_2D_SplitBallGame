using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform ballSpawnPoint;
    public GameObject obstaclePrefab;
    public Transform[] obstacleSpawnPoints;
    public Text scoreText;

    private int score = 0;

    void Start()
    {
        Instantiate(ballPrefab, ballSpawnPoint.position, Quaternion.identity);
        InvokeRepeating("SpawnObstacle", 2f, 3f); // 每隔3秒生成一個障礙物
    }

    void Update()
    {
        scoreText.text = "Score: " + score;
    }

    void SpawnObstacle()
    {
        int spawnIndex = Random.Range(0, obstacleSpawnPoints.Length);
        Instantiate(obstaclePrefab, obstacleSpawnPoints[spawnIndex].position, Quaternion.identity);
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
    }
}
