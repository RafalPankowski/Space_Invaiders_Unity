using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Collision
{
    private float ySpeed = 0.75f;
    protected Vector3 bulletMove;
    public Transform bullet;

    private void FixedUpdate()
    {
        Shoot();
        BulletDestroy();
    }

    void Shoot()
    {
     bulletMove = new Vector3(0, ySpeed, 0);
     transform.Translate(0, bulletMove.y * Time.deltaTime, 0);
    }

    void BulletDestroy()
    {
        if(transform.position.y > 2.0f)
        {
            Destroy(gameObject);
        }
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Fighter")
        {
            Destroy(this.gameObject);
            Destroy(coll.gameObject);
            GameManager.instance.IncreaseScore(GameManager.instance.points);
        }
    }
}
