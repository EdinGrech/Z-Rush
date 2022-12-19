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

    static int score = 0;
    static public int returnScore()
    {
        return score;
    }

    static public void setScore(int scoreValue)
    {
        score = scoreValue;
    }

    public void resetScore()
    {
        score = 0;
        Destroy(gameObject);
    }
}
