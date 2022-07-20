using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDMenu : MonoBehaviour
{
    public static HUDMenu instance;
    public Text pointsText;
    public GameObject preLive;
    public RectTransform healthbar;
    public int lives;
    float x;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        lives = GameManager.instance.player.hitpoint;
        Lives();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        pointsText.text = GameManager.instance.totalscore.ToString();
    }

    void Lives()
    {
        for(int i = 1; i <= lives; i++)
        {
            GameObject lives = Instantiate(preLive);
            lives.transform.position = healthbar.transform.position + new Vector3(100f,25f);
            lives.transform.Translate(x, 0, 0);
            lives.transform.parent = gameObject.transform;
            x += 50f;
            lives.name = "Live" + i;
        }
    }
    public void Player_hited()
    {
        GameObject targetLive = GameObject.Find("Live" + lives);
        Destroy(targetLive);
        lives--;
        GameManager.instance.player.hitpoint--;

        if(lives == 0)
        {
            GameManager.instance.Lose();
        }
    }

}
