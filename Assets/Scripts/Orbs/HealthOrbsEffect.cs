using UnityEngine;
using System.Collections;

public class HealthOrbsEffect : MonoBehaviour
{
    public GameObject player;
    PlayerHealth playerHealth;
    float timer;

    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent <PlayerHealth> ();
        Debug.Log("playerHealth");
        Debug.Log(playerHealth);
        Destroy(gameObject, 10.0f);
        
    }

    // Callback jika ada suatu object masuk ke dalam trigger
    void OnTriggerEnter (Collider other)
    {
        // Set player in range
        if (other.gameObject == player)
        {
            playerHealth.currentHealth += 10;
            if(playerHealth.currentHealth > playerHealth.startingHealth){
                playerHealth.currentHealth = playerHealth.startingHealth;
            }
            Destroy(gameObject);
        }
    }
}
