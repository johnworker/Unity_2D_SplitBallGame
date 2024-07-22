using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    void Update()
    {
        // 使用左右箭頭鍵控制砲台移動
        float move = Input.GetAxis("Horizontal") * Time.deltaTime * 5.0f;
        transform.Translate(move, 0, 0);

        // 按下空格鍵發射子彈
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
    }
}
