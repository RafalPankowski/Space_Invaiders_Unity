using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Movement
{
    public Bullet bulletPrefarb;
    private float cooldown = 0.5f;
    private float lastShoot;
    protected override void Start()
    {
        base.Start();
    }


    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        UpdateMotor(new Vector3(x, 0, 0));
    }

    protected virtual void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastShoot > cooldown)
            {
                lastShoot = Time.time;
                Vector3 PBullet = new Vector3(transform.position.x, -0.55f, 0);
                Instantiate(bulletPrefarb, PBullet, Quaternion.identity);
            }
        }
    }

    protected override void UpdateMotor(Vector3 input)
    {
        base.UpdateMotor(input);
        if (transform.position.x > 1.2f)
        {
            transform.Translate(-0.01f, 0, 0);
        }
        if (transform.position.x < -1.2f)
        {
            transform.Translate(0.01f, 0, 0);
        }
    }
}
