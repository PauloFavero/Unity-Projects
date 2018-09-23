using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {

    public const int maxHealth = 100;
    public RectTransform healthBar;
    public bool destroyOnDeath;
    private NetworkStartPosition[] spawnPoints;


    [SyncVar(hook = "OnChangeHealth")]
    public int currentHealth = maxHealth;

    [ClientRpc]
    void RpcRespawn()
    {
        if(isLocalPlayer)
        {
            // Set the spawn point to origin as a default value
            Vector3 spawnPoint = new Vector3(0, 1, 0);

            // If there is a spawn point array and the array is not empty, pick a spawn point at random
            if (spawnPoints != null && spawnPoints.Length > 0)
            {
                spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            }

            // Set the player’s position to the chosen spawn point
            transform.position = spawnPoint;
        }
    }

    void Start()
    {
        if (isLocalPlayer)
        {
            spawnPoints = FindObjectsOfType<NetworkStartPosition>();
        }
    }
    public void TakeDamage(int amount){

        if (isServer)
        {
            currentHealth -= amount;
            Debug.Log("Hit!");

            if (currentHealth <= 0)
            {

                if (destroyOnDeath)
                {
                    Destroy(gameObject);
                }
                else
                {
                    currentHealth = maxHealth;
                    RpcRespawn();
                    Debug.Log("Dead!");
                }
               
            }

          
        }
    }
    void OnChangeHealth(int health)
    {
        healthBar.sizeDelta = new Vector2(health, healthBar.sizeDelta.y);
    }
}
