using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoEn : MonoBehaviour
{
    List<Transform> wayPoints;
    waveConf waveConfig;
    short waypointIndex = 0;

    void Start()
    {
        wayPoints = loadPoints();
        transform.position = wayPoints[wayPoints.Count-1].transform.position;
    }
    
    List<Transform> loadPoints()
    {
        List<Transform> path = new List<Transform>();
        foreach (Transform child in GameObject.Find(waveConfig.readPath().transform.GetChild(Random.Range(0,2)).name).transform)
        {
            path.Add(child);
        }
        return path;
    }

    void Update()
    {
        eMove();
    }

    public void setWaveConfig(waveConf waveConfToSave)
    {
        waveConfig = waveConfToSave;
    }

    void eMove()
    {
        if (waypointIndex < wayPoints.Count)
        {
            var targetPos = wayPoints[wayPoints.Count-1-waypointIndex].transform.position;
            targetPos.z = 0f;

            var changePrFr = waveConfig.readObstSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, changePrFr);

            if (transform.position == targetPos)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Destroy(gameObject);
    //}
}
