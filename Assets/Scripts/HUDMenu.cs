using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class HUDMenu : MonoBehaviour
{
    public Text pointsText;

    public Image lives;
    void Awake()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        pointsText.text = GameManager.instance.totalscore.ToString();
    }

}
