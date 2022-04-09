using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbsManager : MonoBehaviour
{
    public GameObject player;
    public float spawnTime = 10f;
    public float timeSinceSpawn;
    public Transform[] spawnPoints;
    public GameObject orb;
    PlayerHealth playerHealth;
    void Start(){
        //Mengeksekusi fungs Spawn setiap beberapa detik sesui dengan nilai spawnTime
        playerHealth = player.GetComponent <PlayerHealth> ();
        InvokeRepeating("Spawn", timeSinceSpawn, spawnTime);
    }

    void Spawn(){
        //Jika player telah mati maka tidak membuat enemy baru
        // if (playerHealth.currentHealth <= 0f){
        // return;
        // }

        //Mendapatkan nilai random
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(orb, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        Debug.Log(spawnPointIndex);
    }
}
