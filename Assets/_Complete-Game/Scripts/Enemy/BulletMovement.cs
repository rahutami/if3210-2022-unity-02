using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{
public class BulletMovement : MonoBehaviour
{
    public int attackDamage = 10;
    public float speed;
    GameObject player;                          // Reference to the player GameObject.
    PlayerHealth playerHealth;                  // Reference to the player's health.

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            if (playerHealth.currentHealth > 0)
            {
                // ... damage the player.
                playerHealth.TakeDamage(attackDamage);
            }
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Environment")
            {
                Destroy(gameObject);
            }
    }
}

}
