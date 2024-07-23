using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject smallerBallPrefab;
    public float speed = 2f;

    void Start()
    {
        // 設置初始運動方向
        GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            SplitBall();
            Destroy(gameObject);
        }
    }

    void SplitBall()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject smallerBall = Instantiate(smallerBallPrefab, transform.position, Quaternion.identity);
            smallerBall.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * speed;
        }
    }
}