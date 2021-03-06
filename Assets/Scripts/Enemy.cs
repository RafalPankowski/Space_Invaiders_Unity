using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Collision
{
    public void Enemy_Death()
    {
        Destroy(this.gameObject);
        GameManager.instance.IncreaseScore(1);
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
