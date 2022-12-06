using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class hpDisplay : MonoBehaviour
{
    player playerStat;
    TextMeshProUGUI uGUI;
    
    void Start()
    {
        uGUI = gameObject.GetComponent<TextMeshProUGUI>();
        playerStat = FindObjectOfType<player>();
    }

    int score = 0;
    void Update()
    {
        if (playerStat.returnHP() < 0)
        {
            score = 0;
        }
        else
        {
            score = playerStat.returnHP();
        }
        uGUI.text = score.ToString();
    }
}
