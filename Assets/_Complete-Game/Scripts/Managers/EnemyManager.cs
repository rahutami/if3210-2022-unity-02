﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{
    public class EnemyManager : MonoBehaviour
    {
        public PlayerHealth playerHealth;       // Reference to the player's heatlh.
        public GameObject[] enemyList;                // The enemy prefab to be spawned
        public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
        public string gameMode;
        float zenTime;
        float zenThreshold;

        // anggep aja zombear 0, zobunny 1, skeleton 2, bomber 3, boss 4

        readonly int[] enemyWeight = { 1, 1, 2, 2, 5 };

        public int waveNum;       
        int waveWeight;
        int countWaveWeight;    // to count in while loops spawn
        int randomInt;
        int enemyAmount;   

        void Start ()
        {
            // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
            //InvokeRepeating ("Spawn", spawnTime, spawnTime);
            if (gameMode == "zen")
            {
                StartZen();
            }
            else
            {
                StartWave();
            }
        }

        void Update()
        {
            if (playerHealth.currentHealth <= 0) return;
            if (gameMode == "zen")
            {
                zenTime += Time.deltaTime;
                if (zenTime > zenThreshold)
                {
                    waveNum++;
                    zenThreshold += zenThreshold;
                    Debug.Log("wave: " + waveNum);
                }
            }
            else
            {
                if (waveNum == 16)
                {
                    playerHealth.currentHealth = 0;
                }
                if (enemyAmount == 0)
                {
                    StartCoroutine(NextWave());
                    enemyAmount = 1; // supaya keluar dari update
                }
            }

        }

        void Spawn ()
        {
            // spawn boss
            if (waveNum % 3 == 0)
            {
                Instantiate(enemyList[4], spawnPoints[4].position, spawnPoints[4].rotation);
                enemyAmount++;
            }

            // random spawn mobs
            while (countWaveWeight < waveWeight)
            {
                // asumsi: skeleton & bomber baru keluar mulai wave 7
                if ((waveWeight - countWaveWeight) == 1 || waveNum < 7)
                {
                    randomInt = Random.Range(0, 2);
                }

                else
                {
                    randomInt = Random.Range(0, 4);
                }

                SpawnMobs();
                countWaveWeight += enemyWeight[randomInt];
                enemyAmount++;
            }

            enemyAmount--; // adjust
        }

        void SpawnMobs()
        {
            Instantiate(enemyList[randomInt], spawnPoints[randomInt].position, spawnPoints[randomInt].rotation);
        }

        void StartWave()
        {
            waveNum = 1;
            waveWeight = 5;
            countWaveWeight = 0;
            enemyAmount = 1; // masalah update

            Spawn();
        }

        IEnumerator NextWave()
        {
            waveNum += 1;
            waveWeight += 2;
            countWaveWeight = 0;

            yield return new WaitForSecondsRealtime(3);

            Spawn();
        }

        public void IncreaseKill()
        {
            enemyAmount--;
        }

        void StartZen()
        {
            zenTime = 0.0f;
            zenThreshold = 5f;
            waveNum = 0;

            InvokeRepeating("SpawnZombear", 4, 4);
            InvokeRepeating("SpawnZombunny", 4, 4);
            InvokeRepeating("SpawnSkeleton", 4, 4);
            InvokeRepeating("SpawnBomber", 4, 4);
            InvokeRepeating("SpawnBoss", 4, 4);
        }

        void SpawnZombear()
        {
            Instantiate(enemyList[0], spawnPoints[0].position, spawnPoints[0].rotation);
        }

        void SpawnZombunny()
        {
            Instantiate(enemyList[1], spawnPoints[1].position, spawnPoints[1].rotation);
        }

        void SpawnSkeleton()
        {
            Instantiate(enemyList[2], spawnPoints[2].position, spawnPoints[2].rotation);
        }

        void SpawnBomber()
        {
            Instantiate(enemyList[3], spawnPoints[3].position, spawnPoints[3].rotation);
        }

        void SpawnBoss()
        {
            Instantiate(enemyList[4], spawnPoints[4].position, spawnPoints[4].rotation);
        }
    }
}