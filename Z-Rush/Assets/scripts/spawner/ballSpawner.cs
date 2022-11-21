using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballSpawner : MonoBehaviour
{
    [SerializeField] GameObject slidingPath;
    bool spawnedAll = false;
    byte pointHead2 = 1;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = slidingPath.transform.GetChild(0).transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move()
    {
        spawnedAll = gameObject.GetComponent<ballDrop>().getSpawnedAll();
        if (!spawnedAll)
        {
            var targetPos = slidingPath.transform.GetChild(pointHead2).transform.position;
            targetPos.z = 0f;

            var changePrFr = 5f * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, changePrFr);

            if (transform.position == targetPos)
            {
                if (pointHead2 == 0) { pointHead2 = 1; }
                else { pointHead2 = 0; }
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
