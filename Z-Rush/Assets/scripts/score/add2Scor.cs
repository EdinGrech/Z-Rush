using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class add2Scor : MonoBehaviour
{
    [SerializeField] int scoreValue = 10;
    public float returnScor()
    {
        return scoreValue;
    }

    public void onHit()
    {
        Destroy(gameObject);
    }
}
