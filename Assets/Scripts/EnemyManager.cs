using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Movement
{
    public static EnemyManager instance;

    private float mCooldown = 0.5f;
    public GameObject preEnemy;
    private float x = -0.5f;
    private bool changedDirection = false;
    public int enemyCount;

    private void Awake()
    {
        instance = this;
        transform.position = Vector3.zero;
    }

    protected override void Start()
    {
        base.Start();
        SpawnEnemy();
        xSpeed = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMotor(new Vector3(x, 0, 0));
        EnemyCounter();
    }

    private void SpawnEnemy()
    {
        for (float y = 0.7f; y >= 0.1f; y -= 0.2f)
        {
            for (float x = -0.8f; x <= 0.8f; x += 0.2f)
            {
                GameObject enemy = Instantiate(preEnemy);
                enemy.transform.position = new Vector3(x, y, 0);
                enemy.transform.parent = gameObject.transform;
                enemyCount++;
            }
        }
    }

    private void EnemyCounter()
    {
        if(enemyCount == 0)
        {
            GameManager.instance.Win();
        }
    }

    protected override void UpdateMotor(Vector3 input)
    {
        base.UpdateMotor(input);

        foreach (var enemyObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {
            if (enemyObj.name == "Enemy(Clone)" && changedDirection == false)
            {

                if (enemyObj.transform.position.x > 1.2f)
                {
                    transform.Translate(0, -0.1f, 0);
                    x = -0.5f;
                    xSpeed += 0.03f;
                    changedDirection = true;
                    StartCoroutine(DirectionCooldown());
                    GameManager.instance.points++;
                }
                if (enemyObj.transform.position.x < -1.2f)
                {
                    transform.Translate(0, -0.1f, 0);
                    x = 0.5f;
                    xSpeed += 0.03f;
                    changedDirection = true;
                    StartCoroutine(DirectionCooldown());
                    GameManager.instance.points++;
                }
                if (enemyObj.transform.position.y < -0.6)
                {
                    GameManager.instance.Lose();
                }
            }
        }
    }

    IEnumerator DirectionCooldown()
    {
        yield return new WaitForSeconds(mCooldown);
        changedDirection = false;
    }
}
