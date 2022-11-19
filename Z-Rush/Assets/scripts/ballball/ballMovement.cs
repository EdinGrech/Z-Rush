using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMovement : MonoBehaviour
{
    waveConf waveConfig;
    [SerializeField] float moveSpeed = 6f;

    public void setWaveConfig(waveConf waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -waveConfig.readObstSpeed());
        Destroy(gameObject, 11/waveConfig.readObstSpeed());
    }

    //ball fall down and destro after leavign screen
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Destroy(gameObject);
    //}   
}
