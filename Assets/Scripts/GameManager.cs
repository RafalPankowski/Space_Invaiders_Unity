using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject wynik;
    public static GameManager instance;
    public string res;
    public Text text;
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
    public void Win()
    {
        SceneManager.LoadScene("GameOver");
        res = " You win! Scored: " + totalscore.ToString() + " points";
    }

    public void Lose()
    {
        SceneManager.LoadScene("GameOver");
        res = " You lose! Scored: " + totalscore.ToString() + " points";

    }
}
