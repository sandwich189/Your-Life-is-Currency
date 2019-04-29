using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private GameManager gm;
    public float spawnTime = 3f;
    private float timeBtwSpawn = 0;
    public Transform[] spawnPoints;
    public GameObject enemy;

    public int daySpawnTime;
    public int nightSpawnTime;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (gm.day)
        {
            spawnTime = daySpawnTime;
        }

        if (gm.night)
        {
            spawnTime = nightSpawnTime;
        }

        if (timeBtwSpawn <= 0)
        {
            Spawn(gm.day);
            timeBtwSpawn = spawnTime;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }

    void Spawn(bool day)
    {
        if (day)
        {
            int random = Random.Range(0, 4);

            Instantiate(enemy, spawnPoints[random].position, spawnPoints[random].rotation);
        }

        if (!day)
        {
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                Instantiate(enemy, spawnPoints[i].position, spawnPoints[i].rotation);
            }
        }
        
    }
}
