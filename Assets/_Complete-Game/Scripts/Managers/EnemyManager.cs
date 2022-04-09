using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{
    public class EnemyManager : MonoBehaviour
    {
        public PlayerHealth playerHealth;       // Reference to the player's heatlh.
        public GameObject[] enemyList;                // The enemy prefab to be spawned
        public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.

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
            StartWave();
        }

        void Update()
        {
            //Debug.Log(enemyKilled);
            //Debug.Log(enemyAmount);
            if (playerHealth.currentHealth <= 0) return;
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

                Instantiate(enemyList[randomInt], spawnPoints[randomInt].position, spawnPoints[randomInt].rotation);
                countWaveWeight += enemyWeight[randomInt];
                enemyAmount++;
            }

            enemyAmount--; // adjust
        }

        void SpawnSkeleton()
        {
            while (countWaveWeight < waveWeight)
            {
                Instantiate(enemyList[2], spawnPoints[2].position, spawnPoints[2].rotation);
                countWaveWeight += enemyWeight[3];
                enemyAmount++;
            }

            enemyAmount--; // adjust
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
            Debug.Log("amount:" + waveWeight);
        }

        public void IncreaseKill()
        {
            enemyAmount--;
        }
    }
}