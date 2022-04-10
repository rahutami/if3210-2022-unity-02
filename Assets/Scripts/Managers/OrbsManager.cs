using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbsManager : MonoBehaviour
{
    public GameObject player;
    float spawnTime = 30.0f;
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
        // Jika player telah mati maka tidak membuat orb baru
        // if (playerHealth.currentHealth <= 0f){
        // return;
        // }
        Debug.Log("newOrb", orb);
        //Mendapatkan nilai random
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        GameObject newOrb = (GameObject) Instantiate(orb, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
