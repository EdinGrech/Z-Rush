using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class spawner : MonoBehaviour
{
    [SerializeField] List<waveConf> waveConfigList;
    [SerializeField] bool looping = false;
    int startingWave = 0;

    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(RunThroughWaves());
        }
        while (looping == true);
    }

    IEnumerator spawnAllEnemiesInWave(waveConf waveConfig)
    {
        List<UnityEngine.Transform> path = new List<UnityEngine.Transform>();
        foreach (UnityEngine.Transform child in GameObject.Find(waveConfig.readPath().name).transform)
        {
            path.Add(child);
        }
        for (int eCount = 0; eCount <= waveConfig.readObstCount(); eCount++)
        {
            GameObject foodObst = Instantiate(waveConfig.readObstPrefab(), path[0].transform.position, Quaternion.identity);
            foodObst.GetComponent<autoEn>().setWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.returnTimeBetweenSpawn() + (eCount / waveConfig.readObstCount()));//needs tweekin
        }
    }

    IEnumerator RunThroughWaves()
    {
        foreach (waveConf wave in waveConfigList)
        {
            //waveConfig currentWave = waveConfigList[startingWave];
            yield return StartCoroutine(spawnAllEnemiesInWave(wave));
        }
    }
}
