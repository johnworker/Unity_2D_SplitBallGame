using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject smallerBallPrefab;
    public GameObject rewardBallPrefab; // 獎勵球的預製件
    public float speed = 2f;
    private int hitCount = 0; // 碰撞計數器

    void Start()
    {
        // 設置初始運動方向
        GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            hitCount++; // 每次碰撞增加計數
            if (hitCount >= 2)
            {
                // 轉變為獎勵球
                TransformToReward();
            }
            else
            {
                // 分裂球
                SplitBall();
            }
            Destroy(collision.gameObject); // 銷毀子彈
        }
    }

    void SplitBall()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject smallerBall = Instantiate(smallerBallPrefab, transform.position, Quaternion.identity);
            smallerBall.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * speed;
        }
        Destroy(gameObject); // 銷毀原始球體
    }

    void TransformToReward()
    {
        // 創建獎勵球
        Instantiate(rewardBallPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject); // 銷毀原始球體
    }
}