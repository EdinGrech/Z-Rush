using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEngine.RuleTile.TilingRuleOutput;

public class spawner : MonoBehaviour
{
    [SerializeField] GameObject ballSpawner;
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

    public IEnumerator spawnAllEnemiesInWave(waveConf waveConfig)
    {
        List<UnityEngine.Transform> path = new List<UnityEngine.Transform>();
        foreach (UnityEngine.Transform child in GameObject.Find(waveConfig.readPath().name).transform)
        {
            path.Add(child);
        }
        //List<UnityEngine.Transform> path = new List<UnityEngine.Transform>();
        //List<List<UnityEngine.Transform>> pathList = new List<List<UnityEngine.Transform>>();
        //foreach (GameObject childOfMain in waveConfig.readPath().transform)
        //{
        //    Debug.Log(childOfMain.name);
        //    foreach (UnityEngine.Transform child in GameObject.Find(childOfMain.name).transform)
        //    {
        //        path.Add(child);
        //    }
        //    pathList.Add(path);
        //}
        GameObject bSpawner = Instantiate(ballSpawner, GameObject.Find("p1").transform.position, Quaternion.identity);
        bSpawner.GetComponent<ballDrop>().setWaveConfig(waveConfig);
        for (int eCount = 0; eCount <= waveConfig.readObstCount(); eCount++)
        {
            GameObject foodObst = Instantiate(waveConfig.readObstPrefab(), path[0].transform.position, Quaternion.identity);
            foodObst.GetComponent<autoEn>().setWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.returnTimeBetweenSpawn() + (eCount / waveConfig.readObstCount()));//needs tweekin
        }
        yield return new WaitForSeconds(waveConfig.returnTimeBetweenSpawn() * waveConfig.readObstCount());
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
