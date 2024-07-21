using UnityEngine;

public class BallController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject ballPrefab;
    public int scoreIncrement = 10;
    private bool isSplit = false;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space) && !isSplit)
        {
            Split();
        }
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(new Vector3(moveX, moveY, 0));
    }

    void Split()
    {
        isSplit = true;
        GameObject newBall1 = Instantiate(ballPrefab, transform.position + Vector3.right, Quaternion.identity);
        GameObject newBall2 = Instantiate(ballPrefab, transform.position + Vector3.left, Quaternion.identity);

        newBall1.GetComponent<BallController>().isSplit = true;
        newBall2.GetComponent<BallController>().isSplit = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject); // 碰到障礙物時銷毀球體
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ScoreZone"))
        {
            gameManager.IncreaseScore(scoreIncrement); // 進入得分區域時增加分數
        }
    }
}
