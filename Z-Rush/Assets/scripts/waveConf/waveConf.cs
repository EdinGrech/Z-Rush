using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Obstical Waves")]
public class waveConf : ScriptableObject
{
    [SerializeField] GameObject obstPrefab;
    public GameObject readObstPrefab()
    {
        return obstPrefab;
    }   
    [SerializeField] GameObject pathPrefab;
    public GameObject readPath()
    {       
        return pathPrefab;
    }
    //public List<Transform> readPath()
    //{
    //    List<Transform> path = new List<Transform>();
    //    foreach (Transform child in pathPrefab.transform)
    //    {
    //        path.Add(child);
    //    }
    //    return path;
    //}
    [SerializeField] short obstDmg = 1;
    public short readObstDmg()
    {
        return obstDmg;
    }
    [SerializeField] float obstSpeed = 10f;
    public float readObstSpeed()
    {
        return obstSpeed;
    }
    [SerializeField] short obstCount = 10;
    public short readObstCount()
    {
        return obstCount;
    }
    [SerializeField] float timeBetweenSpawn = 0.5f;
    public float returnTimeBetweenSpawn()
    {
        return timeBetweenSpawn;
    }
}
