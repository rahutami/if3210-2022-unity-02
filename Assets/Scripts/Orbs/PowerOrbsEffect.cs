using UnityEngine;
using System.Collections;

public class PowerOrbsEffect : MonoBehaviour
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
            PlayerPower.currentPower += 20;
            if(PlayerPower.currentPower > PlayerPower.maxPower){
                PlayerPower.currentPower = PlayerPower.maxPower;
            }
            Destroy(gameObject);
        }
    }
}
