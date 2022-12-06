using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameSetion : MonoBehaviour
{

    private void Awake()
    {
        SetupSingolton();
    }
    
    void SetupSingolton()
    {
        if (FindObjectsOfType<gameSetion>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    int score = 0;
    public int returnScore()
    {
        return score;
    }

    public void setScore(int scoreValue)
    {
        score = scoreValue;
    }

    public void resetScore()
    {
        DestroyObject(gameObject);
    }
}
