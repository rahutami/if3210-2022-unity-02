using UnityEngine;
using System.Collections;

public class PowerOrbsEffect : MonoBehaviour
{
    public GameObject player;
    PlayerPower playerPower;
    float timer;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerPower = player.GetComponent <PlayerPower> ();
        Destroy(gameObject, 10.0f);
    }

    // Callback jika ada suatu object masuk ke dalam trigger
    void OnTriggerEnter (Collider other)
    {
        // Set player in range
        if (other.gameObject == player)
        {
            playerPower.currentPower += 20;
            Destroy(gameObject);
        }
    }
}
