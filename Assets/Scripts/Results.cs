using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Results : MonoBehaviour
{
    public Text textWynik;
    void Awake()
    {
        textWynik.text = GameManager.instance.res;
    }

    public void Again()
    {
        GameManager.instance.totalscore = 0;
        SceneManager.LoadScene("Game");
    }
}
