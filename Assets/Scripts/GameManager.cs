using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    void Awake()
    {
        instance = this;
    }

    public Player player;
    public GameObject hud;
    public int totalscore;
    public int hp;
    public int points = 1;
 
    void Update()
    {
        
    }
    public void IncreaseScore(int score)
    {
        totalscore += score;
    }
}
