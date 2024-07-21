using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public BallController ballController;

    void Start()
    {
        ballController = FindObjectOfType<BallController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ballController.SpawnBall();
        }
    }
}
