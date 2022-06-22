using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Movement
{
    private float mCooldown = 0.5f;
    private float lastMove;
    public GameObject preEnemy;
    private float x = -0.5f;

    private void Awake()
    {
        transform.position = Vector3.zero;
    }

    protected override void Start()
    {
        base.Start();
        SpawnEnemy();
        xSpeed = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMotor(new Vector3(x, 0, 0));
    }

    private void SpawnEnemy()
    {
        for (float y = 0.8f; y >= 0.2f; y -= 0.2f)
        {
            for (float x = -0.8f; x <= 0.8f; x += 0.2f)
            {
                GameObject enemy = Instantiate(preEnemy);
                enemy.transform.position = new Vector3(x, y, 0);
                enemy.transform.parent = gameObject.transform;
            }
        }
    }

    protected override void UpdateMotor(Vector3 input)
    {
        base.UpdateMotor(input);

        foreach (var enemyObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {
            if (enemyObj.name == "Enemy(Clone)")
            {

                if (enemyObj.transform.position.x > 1.2f || enemyObj.transform.position.x < -1.2f)
                {
                    transform.Translate(0, -0.02f, 0);
                    x = -0.5f;
                }
            }
        }
    }
}
