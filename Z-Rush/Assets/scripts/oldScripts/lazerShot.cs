using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazerShot : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]float disTime = 0.4f;
    void Start()
    {
        Destroy(gameObject, disTime);
    }
}
