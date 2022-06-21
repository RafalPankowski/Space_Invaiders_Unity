using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{ 
    protected BoxCollider2D boxCollider;
    protected Vector3 moveDelta;
    protected RaycastHit2D hit;
    public float xSpeed = 0.5f;
    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void UpdateMotor(Vector3 input)
    {
        moveDelta = new Vector3(input.x * xSpeed, input.y, 0);
        
        transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);

        if(transform.position.x > 1.2f)
        {
            transform.Translate(-0.01f, 0, 0);
        }
        if (transform.position.x < -1.2f)
        {
            transform.Translate(0.01f, 0, 0);
        }
    }
}
