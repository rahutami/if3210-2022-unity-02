using UnityEngine;
using System.Collections;

public class SpeedOrbsEffect : MonoBehaviour
{
    public GameObject player;
    PlayerSpeed playerSpeed;
    float timer;

    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerSpeed = player.GetComponent <PlayerSpeed> ();
        Destroy(gameObject, 10.0f);
    }

    // Callback jika ada suatu object masuk ke dalam trigger
    void OnTriggerEnter (Collider other)
    {
        // Set player in range
        if (other.gameObject == player)
        {
            playerSpeed.currentSpeed += 25;
            if(playerSpeed.currentSpeed > playerSpeed.maxSpeed){
                playerSpeed.currentSpeed = playerSpeed.maxSpeed;
            }
            Destroy(gameObject);
        }
    }
}
