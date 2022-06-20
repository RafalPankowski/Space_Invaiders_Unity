using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Movement
{

    protected override void Start()
    {
        base.Start();
    }


    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");

        UpdateMotor(new Vector3(x, 0, 0));
    }
}
