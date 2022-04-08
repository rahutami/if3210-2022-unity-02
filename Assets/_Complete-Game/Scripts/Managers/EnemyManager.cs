using System.Collections;
using UnityEngine;

namespace CompleteProject
{
    public class EnemyManager : MonoBehaviour
    {
        public PlayerHealth playerHealth;       // Reference to the player's heatlh.
        public GameObject enemy;                // The enemy prefab to be spawned.
        public float spawnTime = 3f;            // How long between each spawn.
        public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.

        private int waveNum;
        private int enemyAmount;
        private int enemyKilled;


        void Start ()
        {
            // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
            //InvokeRepeating ("Spawn", spawnTime, spawnTime);
            StartWave();
        }

        void Update()
        {
            Debug.Log(enemyKilled);
            //Debug.Log(enemyAmount);
            if (enemyKilled >= enemyAmount)
            {
                Debug.Log("as");
                StartCoroutine(Delay(3));
                NextWave();
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

            // Find a random index between zero and one less than the number of spawn points.
            int spawnPointIndex = Random.Range (0, spawnPoints.Length);

            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }

        private void StartWave()
        {
            waveNum = 1;
            enemyAmount = 2;
            enemyKilled = 0;

            for (int i = 0; i < enemyAmount; i++)
            {
                Spawn();
            }
        }

        public void NextWave()
        {
            waveNum += 1;
            enemyAmount += 2;
            enemyKilled = 0;

            for (int i = 0; i < enemyAmount; i++)
            {
                Spawn();
            }
        }

        private IEnumerator Delay(float time)
        {
            yield return new WaitForSeconds(time);
        }

        public void IncreaseKill()
        {
            enemyKilled++;
            Debug.Log(enemyKilled);
        }
    }
}