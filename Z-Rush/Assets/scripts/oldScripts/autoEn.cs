using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoEn : MonoBehaviour
{
    List<Transform> wayPoints;
    [SerializeField] float eSpeed = 4f;
    short waypointIndex = 5;
    genPath scc;
    
    void Start()
    {
        IEnumerator childLookUp = initWayPts();
        StartCoroutine(childLookUp);
    }

    void Update()
    {
        eMove();
    }

    IEnumerator initWayPts()
    {
        GameObject AutoPath = GameObject.Find("AutoPath");
        scc = AutoPath.GetComponent<genPath>();

        while (!scc.returnSetUpStat())
        { yield return new WaitForFixedUpdate(); }

        Debug.Log(AutoPath.transform.childCount);
        for (int i = 0; i < AutoPath.transform.childCount; i++)
        {
            Debug.Log(AutoPath.transform.GetChild(i).transform);
            wayPoints.Add(AutoPath.transform.GetChild(i).transform);
            Debug.Log(wayPoints[i].transform.position);
        }
        Debug.Log(wayPoints);
        transform.position = wayPoints[0].transform.position;
    }

    void eMove()
    {
        Debug.Log(wayPoints);
        if (waypointIndex < wayPoints.Count)
        {
            var targetPos = wayPoints[waypointIndex].transform.position;
            targetPos.z = 0f;

            var changePrFr = eSpeed * Time.deltaTime;
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
}
