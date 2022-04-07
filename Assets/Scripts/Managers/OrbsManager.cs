using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbsManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float spawnTime = 10f;
    public Transform[] spawnPoints;
    public int spawnOrb;

    [SerializeField]
    MonoBehaviour factory;
    IFactory Factory { get { return factory as IFactory; } }

    void Start(){
        //Mengeksekusi fungs Spawn setiap beberapa detik sesui dengan nilai spawnTime
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn(){
        //Jika player telah mati maka tidak membuat enemy baru
        if (playerHealth.currentHealth <= 0f){
           return;
        }

        //Mendapatkan nilai random
       int spawnPointIndex = Random.Range(0, spawnPoints.Length);
       int spawnOrb = Random.Range(0, 3);

        //Memduplikasi enemy
        Factory.FactoryMethod(spawnOrb);
    }
}
