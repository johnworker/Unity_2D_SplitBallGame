using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject ballPrefab; // 分裂球的預製件
    public int initialBallCount = 30; // 初始分裂球數量
    public float ballSpeed = 5f; // 分裂球移動速度
    public Transform spawnPoint; // 分裂球生成點

    private List<GameObject> balls = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < initialBallCount; i++)
        {
            SpawnBall();
        }
    }

    public void SpawnBall()
    {
        GameObject newBall = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
        newBall.GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle * ballSpeed;
        balls.Add(newBall);
    }

    void Update()
    {
        foreach (GameObject ball in balls)
        {
            if (ball.transform.position.magnitude > 10f)
            {
                ball.GetComponent<Rigidbody2D>().velocity = -ball.GetComponent<Rigidbody2D>().velocity;
            }
        }
    }
}
