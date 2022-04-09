using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int waveNum = 0;
    public int enemyAmount = 0;
    public int enemyKilled = 0;

    public GameObject[] spawners;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        spawners = new GameObject[5];
        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i] = transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SpawnEnemy();
        }
        if (enemyKilled >= enemyAmount)
        {
            NextWave();
        }
    }

    private void SpawnEnemy()
    {
        int spawnerID = Random.Range(0, spawners.Length);
        Instantiate(enemy, spawners[spawnerID].transform.position, spawners[spawnerID].transform.rotation);
    }

    private void StartWave()
    {
        waveNum = 1;
        enemyAmount = 2;
        enemyKilled = 0;

        for (int i = 0; i < enemyAmount; i++)
        {
            SpawnEnemy();
        }
    }

    public void NextWave()
    {
        waveNum += 1;
        enemyAmount += 2;
        enemyKilled = 0;

        for (int i = 0; i < enemyAmount; i++)
        {
            SpawnEnemy();
        }
    }
}
