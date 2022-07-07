using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Collision
{

    protected override void OnCollide(Collider2D coll)
    {
        if(coll.tag == "Fighter")
        {
            //Destroy(gameObject);
            //Destroy(this);
        }
    }
}
