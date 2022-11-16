using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPathing : MonoBehaviour
{
    [SerializeField] List<Transform> wayPoints;
    [SerializeField] float eSpeed = 4f;
    short waypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = wayPoints[0].transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        eMove();
    }

    void eMove()
    {
        if(waypointIndex < wayPoints.Count)
        {
            var targetPos = wayPoints[waypointIndex].transform.position;
            targetPos.z = 0f;

            var changePrFr = eSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position,targetPos,changePrFr);

            if(transform.position == targetPos)
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
