using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float moveSpeed = 2f;

    void Update()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        if (transform.position.y < -5f)
        {
            Destroy(gameObject); // 障礙物超出屏幕下方時銷毀
        }
    }
}
