using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject smallerBallPrefab;
    public int splitCount = 2;
    public float speed = 2f;

    void Start()
    {
        // 設置初始運動方向
        GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1f, 1f), -1f) * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (splitCount > 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    GameObject smallerBall = Instantiate(smallerBallPrefab, transform.position, Quaternion.identity);
                    smallerBall.GetComponent<Ball>().splitCount = splitCount - 1;
                }
            }
            Destroy(gameObject);
        }
    }
}
