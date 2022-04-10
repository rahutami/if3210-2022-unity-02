using UnityEngine;
using System.Collections;

public class SpeedOrbsEffect : MonoBehaviour
{
    public GameObject player;
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
            PlayerSpeed.currentSpeed += 25;
            if(PlayerSpeed.currentSpeed > PlayerSpeed.maxSpeed){
                PlayerSpeed.currentSpeed = PlayerSpeed.maxSpeed;
            }
            Destroy(gameObject);
        }
    }
}
