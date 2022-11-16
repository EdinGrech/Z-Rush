using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy wave config")]
public class waveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    public GameObject readEnemyPrefab()
    {
        return enemyPrefab;
    }
    [SerializeField] GameObject pathPrefab;
    public GameObject readpathPrefab()
    {
        return pathPrefab;
    }
    [SerializeField] int numberOfEnemies = 5;
    public int returnNumberOfEnemies()
    {
        return numberOfEnemies;
    }
    [SerializeField] float timeBetweenSpawn = 0.5f;
    public float returnTimeBetweenSpawn()
    {
        return timeBetweenSpawn;
    }
    [SerializeField] float enemyMoveSpeed = 2f;
    public float returnEnemyMoveSpeed()
    {
        return enemyMoveSpeed;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
