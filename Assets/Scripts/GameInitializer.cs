using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform[] spawnPoints;

    void Start()
    {
        foreach (var spawnPoint in spawnPoints)
        {
            Instantiate(ballPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
