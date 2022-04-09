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

        // anggep aja skeleton 0, bomber 1, boss 2

        int[] enemyWeight = { 1, 2, 5 };

        int waveNum;       
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
            if (enemyAmount == 0)
            {
                StartCoroutine(NextWave());
                enemyAmount = 1; // supaya keluar dari update
            }
        }

        void Spawn ()
        {
            // If the player has no health left...
            if(playerHealth.currentHealth <= 0f)
            {
                // ... exit the function.
                return;
            }

            // spawn boss
            if (waveNum % 3 == 0)
            {
                Instantiate(enemyList[2], spawnPoints[2].position, spawnPoints[2].rotation);
            }

            // random spawn mobs
            while (countWaveWeight < waveWeight)
            {
                if ((waveWeight - countWaveWeight) == 1)
                {
                    randomInt = 0;
                }

                else
                {
                    randomInt = Random.Range(0, enemyWeight.Length - 1);
                }

                Instantiate(enemyList[randomInt], spawnPoints[randomInt].position, spawnPoints[randomInt].rotation);
                countWaveWeight += enemyWeight[randomInt];
                enemyAmount++;
            }

            enemyAmount--; // adjust
        }

        void StartWave()
        {
            waveNum = 1;
            waveWeight = 5;
            countWaveWeight = 0;
            enemyAmount = 0;

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