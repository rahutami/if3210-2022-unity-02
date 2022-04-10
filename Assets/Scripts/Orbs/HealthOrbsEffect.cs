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
        Destroy(gameObject, 10.0f);
        
    }

    // Callback jika ada suatu object masuk ke dalam trigger
    void OnTriggerEnter (Collider other)
    {
        // Set player in range
        if (other.gameObject == player)
        {
            PlayerHealth.currentHealth += 10;
            if(PlayerHealth.currentHealth > 500){
                PlayerHealth.currentHealth = 500;
            }
            Destroy(gameObject);
        }
    }
}
