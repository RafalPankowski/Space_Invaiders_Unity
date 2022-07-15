using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Collision : Collision
{
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Bullet")
        {
            GameManager.instance.player.hitpoint -= 1;
        }
    }
}
