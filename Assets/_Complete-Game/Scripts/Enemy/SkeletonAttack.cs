using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class SkeletonAttack : MonoBehaviour
    {
        public float timeBetweenAttacks = 2f;     // The time in seconds between each attack.
        public int attackDamage = 10;               // The amount of health taken away per attack.

        public GameObject bullet;


        Animator anim;                              // Reference to the animator component.
        GameObject player;                          // Reference to the player GameObject.
        PlayerHealth playerHealth;                  // Reference to the player's health.
        EnemyHealth enemyHealth;                    // Reference to this enemy's health.
        bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
        float timer;                                // Timer for counting up to the next attack.


        void Awake()
        {
            // Setting up the references.
            player = GameObject.FindGameObjectWithTag("Player");
            playerHealth = player.GetComponent<PlayerHealth>();

            enemyHealth = GetComponent<EnemyHealth>();
            anim = GetComponent<Animator>();
        }

        void Update()
        {
            // Add the time since Update was last called to the timer.
            timer += Time.deltaTime;

            // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
            if (timer >= timeBetweenAttacks && enemyHealth.currentHealth > 0)
            {
                // ... attack.
                Attack();
            }

            // If the player has zero or less health...
            if (PlayerHealth.currentHealth <= 0)
            {
                // ... tell the animator the player is dead.
                anim.SetTrigger("PlayerDead");
            }
        }


        void Attack()
        {
            // Reset the timer.
            timer = 0f;
            Transform playerPos = player.GetComponent<Transform>();
            Vector3 direction = new Vector3(playerPos.position.x - transform.position.x, playerPos.position.y - transform.position.y, playerPos.position.z - transform.position.z);
            transform.up = direction;

            // If the player has health to lose...
            if (PlayerHealth.currentHealth > 0)
            {
                // ... damage the player.
                Instantiate(bullet, transform.position, transform.rotation);
            }
        }
    }
}