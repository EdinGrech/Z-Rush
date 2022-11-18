using System.Collections.Generic;
using UnityEngine;

public class genPath : MonoBehaviour
{
    [SerializeField] float padding = 3;
    [SerializeField] short numberOfPoints = 5;

    private void Awake()
    {   
        float xMin, xMax, yMin, yMax;
        Camera cam = Camera.main;
        xMin = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        xMax = cam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        yMin = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        yMax = cam.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;

        gameObject.transform.position = new Vector3(xMin, yMin, 0);

        float yrange = yMax - yMin;
        float yInit = (yrange / numberOfPoints);

        short rand = (short)Random.Range(1, 4);
        
        //List<Vector3> pointLocs = new List<Vector3>();
        List<GameObject> waypoints = new List<GameObject>();
        for (short i = 0; i < numberOfPoints+3; i++)
        {
            GameObject childPathObj = new GameObject("wayPt " + i);
            childPathObj.transform.parent = gameObject.transform;
            Vector3 ptloc = positioner(i, yInit, rand, xMin, yMin, xMax);
            childPathObj.transform.position = ptloc;
            waypoints.Add(childPathObj);
        }
    }
    
    static Vector3 positioner(short poState, float yInit, short rand, float xMin, float yMin, float xMax)
    {
        Vector3 ptloc = new Vector3();
        switch (rand)
        {
            case 1:
                ptloc = new Vector3((float)Random.Range(xMin + 1, xMax - 1), (yInit * poState-1) + yMin, 0);
                break;
            case 2:
                ptloc = new Vector3((float)Random.Range(xMin + 1, xMax - 1), (yInit * poState-1) + yMin, 0);
                break;
            case 3:
                ptloc = new Vector3((float)Random.Range(xMin + 2, xMax - 2), (yInit * poState-1) + yMin, 0);
                break;
        }
        return ptloc;
    }
}
