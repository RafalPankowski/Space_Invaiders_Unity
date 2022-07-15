using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shooter : Movement
{
    private float lastShoot;
    public float x = -0.5f;
    public Bullet_enemy bulletPrefarb;
    public int shootCount;
    protected override void Start()
    {
        base.Start();
        xSpeed = 1.5f;
    }
    void Update()
    {
        UpdateMotor(new Vector3(x, 0, 0));
        Enemy_Shoot();
    }
    protected override void UpdateMotor(Vector3 input)
    {
        base.UpdateMotor(input);
        if (transform.position.x > 1.2f)
        {
            x = -0.5f;
        }
        if (transform.position.x < -1.2f)
        {
            x = 0.5f;
        }
    }

    private void Enemy_Shoot()
    {
        float shootCooldown = Random.Range(0.9f, 1.6f);
        float immuneTime = 0.6f;

        if (Time.time - lastShoot > shootCooldown + immuneTime)
        {
            lastShoot = Time.time;
            Vector3 PBullet = new Vector3(transform.position.x, 0.75f, 0);
            Instantiate(bulletPrefarb, PBullet, Quaternion.identity);
            shootCount = Random.Range(1,7);
            if(shootCount == 3)
            {
                x *= -1;
            }
            
        }
    }
}
