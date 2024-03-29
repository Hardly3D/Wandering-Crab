﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bullet;
    public GameObject spawningBullet;
    public float shootingCooldown = 10f;
    public float bulletSpeed = 5f;
    float lastShot;

    void Start()
    {
        lastShot = Time.time + shootingCooldown;
    }

    void Update()
    {
        if (Time.time > lastShot)
        {
            Spawner();
            lastShot = Time.time + shootingCooldown;
        }
    }

    void Spawner()
    {
        Vector2 positionToShoot = new Vector2(transform.position.x, transform.position.y);

        spawningBullet = bullet;
        spawningBullet = Instantiate(bullet, positionToShoot + new Vector2(1, 0), Quaternion.identity);
        spawningBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0);
        
        bullet.name = "Bullet"; // To avoid clones.

        spawningBullet = Instantiate(bullet, positionToShoot + new Vector2(-1, 0), Quaternion.identity);
        spawningBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletSpeed, 0);

        bullet.name = "Bullet"; // To avoid clones.
    }
}
