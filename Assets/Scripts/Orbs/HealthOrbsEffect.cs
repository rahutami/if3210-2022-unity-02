using UnityEngine;
using System.Collections;

public class HealthOrbsEffect : MonoBehaviour
{
    PlayerHealth playerHealth;
    float timer;
    GameObject player;

    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent <PlayerHealth> ();
        Destroy(gameObject, 10.0f);
    }

    // Callback jika ada suatu object masuk ke dalam trigger
    void OnTriggerEnter (Collider other)
    {
        // Set player in range
        if (other.gameObject == player)
        {
            playerHealth.currentHealth += 10;
            Destroy(gameObject);
        }
    }
}
