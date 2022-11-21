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
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -waveConfig.readBallSpeed());
        Destroy(gameObject, 11/waveConfig.readBallSpeed());
    }   
}
