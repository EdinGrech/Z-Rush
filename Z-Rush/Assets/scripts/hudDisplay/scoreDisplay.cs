using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scoreDisplay : MonoBehaviour
{
    gameSetion gameSetion;
    TextMeshProUGUI uGUI;
    
    // Start is called before the first frame update
    void Start()
    {
        uGUI = gameObject.GetComponent<TextMeshProUGUI>();
    }

    int score = 0;
    void Update()
    {
        gameSetion = FindObjectOfType<gameSetion>();
        uGUI.text = gameSetion.returnScore().ToString();
    }
}
