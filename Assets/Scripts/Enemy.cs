using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Movement
{
    private float lastShoot;
    private float x = -0.5f;
    public Bullet_enemy bulletPrefarb;
    protected override void Start()
    {
        base.Start();
        xSpeed = 1.7f;
    }
    void Update()
    {
        UpdateMotor(new Vector3(x, 0, 0));

        float shootCooldown = Random.Range(0.9f, 2.6f);

        if (Time.time - lastShoot > shootCooldown)
        {
            lastShoot = Time.time;
            Vector3 PBullet = new Vector3(transform.position.x, 0.75f, 0);
            Instantiate(bulletPrefarb, PBullet, Quaternion.identity);
        }
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
}
