using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 處理碰撞事件，分裂球體
        if (collision.gameObject.CompareTag("Ball"))
        {
            // 分裂邏輯
            Destroy(gameObject);
        }
    }
}
