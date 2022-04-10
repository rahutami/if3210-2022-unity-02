﻿using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent>();
    }


    void Update ()
    {
        //Memindahkan posisi player
        if (enemyHealth.currentHealth > 0 && PlayerHealth.currentHealth > 0)
        {
            nav.SetDestination(player.position);
        }
        else //Hentikan moving
        {
            nav.enabled = false;
        }
    }
}
