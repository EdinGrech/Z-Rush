using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballDrop : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    [SerializeField] float ballSpeed = 5f;
    waveConf waveConfig;
    bool spawnedAll = false;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return StartCoroutine(sendBall(waveConfig));
        }
        spawnedAll = true;
        Debug.Log("spawned all " + spawnedAll);
    }

    public void setWaveConfig(waveConf waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    public bool getSpawnedAll()
    {
        return spawnedAll;
    }

    IEnumerator sendBall(waveConf waveConfig)
    {
        Instantiate(ballPrefab, gameObject.transform.position, Quaternion.identity).GetComponent<ballMovement>().setWaveConfig(waveConfig);
        yield return new WaitForSeconds((waveConfig.returnTimeBetweenSpawn() * waveConfig.readObstCount()) / 8);
    }

}
