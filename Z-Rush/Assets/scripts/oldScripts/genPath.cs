using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genPath : MonoBehaviour
{
    [SerializeField] GameObject pathPerent;
    [SerializeField] short numberOfPoints = 5;
    bool setUpDone = false;
    public bool returnSetUpStat()
    {
        return setUpDone;
    }
    // Start is called before the first frame update
    void Start()
    {
        List<Vector3> pointLocs = new List<Vector3>();
        List<GameObject> waypoints = new List<GameObject>();
        for (short i = 0; i < numberOfPoints; i++)
        {
            GameObject childPathObj = new GameObject("wayPt " + i);
            childPathObj.transform.parent = gameObject.transform;
            Vector3 ptloc = new Vector3(wavePointGen(i), i, 0);
            childPathObj.transform.position = ptloc;
            waypoints.Add(childPathObj);
        }
        setUpDone = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    static float wavePointGen(short wayDex)
    {
        float res = Mathf.Pow(wayDex, 1) - 4;
        return res;
    }
}
